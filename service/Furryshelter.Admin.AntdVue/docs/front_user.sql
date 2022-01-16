-- --------------------------------------------------------
-- 主机:                           127.0.0.1
-- 服务器版本:                        10.6.5-MariaDB - mariadb.org binary distribution
-- 服务器操作系统:                      Win64
-- HeidiSQL 版本:                  11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- 导出  表 furryshelteradmin.front_user 结构
CREATE TABLE IF NOT EXISTS `front_user` (
  `Id` varchar(50) NOT NULL COMMENT '主键',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `CreatorId` varchar(50) DEFAULT NULL COMMENT '创建人Id',
  `Deleted` tinyint(4) NOT NULL DEFAULT 0 COMMENT '否已删除',
  `UserName` VARCHAR(50) DEFAULT NULL COMMENT '用户名',
  `Password` varchar(50) DEFAULT NULL COMMENT '密码',
  `RealName` varchar(50) DEFAULT NULL COMMENT '姓名',
  `Sex` int(11) NOT NULL DEFAULT 0 COMMENT '性别(1为男，0为女)',
  `Phone` varchar(50) DEFAULT NULL COMMENT '电话号码',
  `IdentityCardNo` varchar(50) DEFAULT NULL COMMENT '身份证实名',
  `IfVerifyCardNo` tinyint(4) NOT NULL DEFAULT 0 COMMENT '否已实名',
  `Birthday` date DEFAULT NULL COMMENT '出生日期',
  `Province` varchar(50) DEFAULT NULL COMMENT '省',
  `City` varchar(50) DEFAULT NULL COMMENT '市',
  `IfPet` tinyint(4) NOT NULL DEFAULT 0 COMMENT '否已养宠物',
  `Email` VARCHAR(150) NOT NULL COMMENT '邮箱',
  `EmailCode` VARCHAR(5) DEFAULT NULL COMMENT '邮箱验证码',
  `IfVeryfyEmail` tinyint(4) NOT NULL DEFAULT 0 COMMENT '否已验证邮箱',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='C端用户表';

-- 数据导出被取消选择。

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
