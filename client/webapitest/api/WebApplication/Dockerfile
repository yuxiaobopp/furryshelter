FROM registry.cn-hangzhou.aliyuncs.com/colder-public/aspnet:5.0.2
RUN rm -f /etc/localtime && ln -sv /usr/share/zoneinfo/Asia/Shanghai /etc/localtime && echo "Asia/Shanghai" > /etc/timezone
WORKDIR /app
COPY . .
EXPOSE 5000
ENTRYPOINT ["dotnet", "WebApplication.dll"]