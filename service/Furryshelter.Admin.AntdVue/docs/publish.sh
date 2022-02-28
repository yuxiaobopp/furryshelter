docker容器间通信 桥接
docker network create -d bridge --subnet 172.25.0.0/16 mynet

docker stop mysql-m
docker rm mysql-m
docker run -itd --name mysql-m -p 3306:3306 -v /usr/local/mysql/data:/var/lib/mysql/ -e MYSQL_ROOT_PASSWORD=fUrryshelter_db68_$#@justd mysql:latest

mysql连接到mynet
docker network connect mynet mysql-m

 
docker stop netcore-furryadmin
docker rm netcore-furryadmin
docker rmi furryadmin
cd /root/publishadmin
docker build -t furryadmin .

docker run --name netcore-furryadmin -d -p 50880:5000 --net mynet --ip=172.25.0.3 -v /etc/localtime:/etc/localtime furryadmin -v ./appsettings.json:/app/appsettings.json




docker build -t furryuser .

docker run --name netcore-furryuser -d -p 50881:5000 --net mynet --ip=172.25.1.3 -v /etc/localtime:/etc/localtime furryuser -v ./appsettings.json:/app/appsettings.json

ping 工具安装
apt-get update && apt-get install iputils-ping

docker inspect mysql-m 查看mysql的可访问IP ，数据库连接字符串用这个ip
netcore-furryadmin容器内是可以ping mysql-m的ip的
但是Mysql还不允许这个ip访问root用户操作数据库，所以

修改mysql用户网络权限才可以访问数据库
update user set host ='%' where user='root';
flush privileges;
如果报下面的错：
 Authentication method 'caching_sha2_password' failed. Either use a secure connection, specify the server's RSA public key with ServerRSAPublicKeyFile, or set AllowPublicKeyRetrieval=True.
修改网站配置文件 appsettings.json的数据库连接字符串

如果报错：Access denied for user ‘root‘@‘xxxxx‘ (using password: YES)
解决方法：进入数据库容器并登陆mysql：
创建新用户
create user 'fadmin'@'%' identified by 'password';
执行授权
GRANT ALL PRIVILEGES ON *.* TO 'fadmin'@'%';
刷新
flush privileges;

最终连接字符串改为
 "ConnectionString": "server=172.25.0.4;user id=fadmin;password=fUrryshelter_db68_$#@justd;database=FurryshelterAdmin;SslMode=none;AllowPublicKeyRetrieval=True"


msql中文乱码
show variables like 'character_set%';
apt-get update && apt-get install vim
vim  /etc/mysql/my.cnf

character-set-server=utf8

重启桥接过的mysql
先断开网络
docker network disconnect mynet mysql-m