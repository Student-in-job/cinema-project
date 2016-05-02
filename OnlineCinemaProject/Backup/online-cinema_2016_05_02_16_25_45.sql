-- MySqlBackup.NET 2.0.9.3
-- Dump Time: 2016-05-02 16:25:45
-- --------------------------------------
-- Server version 5.7.10-log MySQL Community Server (GPL)


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of __migrationhistory
-- 

DROP TABLE IF EXISTS `__migrationhistory`;
CREATE TABLE IF NOT EXISTS `__migrationhistory` (
  `MigrationId` varchar(100) NOT NULL,
  `ContextKey` varchar(200) NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`,`ContextKey`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table __migrationhistory
-- 

/*!40000 ALTER TABLE `__migrationhistory` DISABLE KEYS */;

/*!40000 ALTER TABLE `__migrationhistory` ENABLE KEYS */;

-- 
-- Definition of actors
-- 

DROP TABLE IF EXISTS `actors`;
CREATE TABLE IF NOT EXISTS `actors` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=1638 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table actors
-- 

/*!40000 ALTER TABLE `actors` DISABLE KEYS */;
INSERT INTO `actors`(`id`,`name`) VALUES
(8,'Актер1'),
(9,'Актер2'),
(10,'Актер3'),
(11,'Актер4'),
(12,'Актер5'),
(13,'Актер6'),
(14,'Актер7'),
(15,'Актер8'),
(16,'Актер9'),
(17,'Актер10');
/*!40000 ALTER TABLE `actors` ENABLE KEYS */;

-- 
-- Definition of advertiser
-- 

DROP TABLE IF EXISTS `advertiser`;
CREATE TABLE IF NOT EXISTS `advertiser` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `phone_number` varchar(45) DEFAULT NULL,
  `img_url` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=3276 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table advertiser
-- 

/*!40000 ALTER TABLE `advertiser` DISABLE KEYS */;
INSERT INTO `advertiser`(`id`,`name`,`email`,`phone_number`,`img_url`) VALUES
(1,'cocacola','coca@mail.ru','+998935718543',NULL),
(3,'M&Ms','mandms@mail.ru','+998935718545',NULL),
(4,'Alpen Gold','gold@inbox.ru','+998979999999',NULL),
(5,'sarkor','support@sarkor.uz','+998711220000',NULL),
(6,'кинотеатр','cinema@mail.ru','+999999999999',NULL);
/*!40000 ALTER TABLE `advertiser` ENABLE KEYS */;

-- 
-- Definition of aspnetroles
-- 

DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(128) NOT NULL,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=3276 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table aspnetroles
-- 

/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles`(`Id`,`Name`) VALUES
('1a6d70ef-2b86-48da-b36c-b974855a8783','BilingManager'),
('4d5f7e37-2498-40db-9891-ea998b599671','ContentManager'),
('4de2ec91-cce0-46e3-8723-cbea20461ef4','Admin'),
('6fc8922c-be46-445f-aa95-d3b7a7fd9145','PRManager'),
('92b3e227-35be-413e-a9e3-3e82d944a256','User');
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;

-- 
-- Definition of aspnetuserclaims
-- 

DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  `User_Id` varchar(128) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`),
  KEY `User_Id` (`User_Id`),
  CONSTRAINT `IdentityUserClaim_User` FOREIGN KEY (`User_Id`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table aspnetuserclaims
-- 

/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;

/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;

-- 
-- Definition of aspnetuserlogins
-- 

DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `UserId` varchar(128) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`ProviderKey`),
  CONSTRAINT `IdentityUserLogin_User` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table aspnetuserlogins
-- 

/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;

/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;

-- 
-- Definition of aspnetuserroles
-- 

DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(128) NOT NULL,
  `RoleId` varchar(128) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IdentityUserRole_Role` (`RoleId`),
  CONSTRAINT `IdentityUserRole_Role` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `IdentityUserRole_User` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=1365 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table aspnetuserroles
-- 

/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles`(`UserId`,`RoleId`) VALUES
('30fefa72-6173-4470-acab-225fccc85a95','1a6d70ef-2b86-48da-b36c-b974855a8783'),
('ac1da694-6aee-4080-8c69-cac3342baada','1a6d70ef-2b86-48da-b36c-b974855a8783'),
('30fefa72-6173-4470-acab-225fccc85a95','4d5f7e37-2498-40db-9891-ea998b599671'),
('ac1da694-6aee-4080-8c69-cac3342baada','4d5f7e37-2498-40db-9891-ea998b599671'),
('30fefa72-6173-4470-acab-225fccc85a95','4de2ec91-cce0-46e3-8723-cbea20461ef4'),
('ac1da694-6aee-4080-8c69-cac3342baada','4de2ec91-cce0-46e3-8723-cbea20461ef4'),
('30fefa72-6173-4470-acab-225fccc85a95','6fc8922c-be46-445f-aa95-d3b7a7fd9145'),
('ac1da694-6aee-4080-8c69-cac3342baada','6fc8922c-be46-445f-aa95-d3b7a7fd9145'),
('26562a37-7fe5-4ed4-88a0-c51ce0652aa3','92b3e227-35be-413e-a9e3-3e82d944a256'),
('30fefa72-6173-4470-acab-225fccc85a95','92b3e227-35be-413e-a9e3-3e82d944a256'),
('7d1b1cb6-9a14-455c-bd78-dcad5c115ad1','92b3e227-35be-413e-a9e3-3e82d944a256'),
('891d17ed-78f3-4809-a4cc-3c16d6b552d9','92b3e227-35be-413e-a9e3-3e82d944a256'),
('ac1da694-6aee-4080-8c69-cac3342baada','92b3e227-35be-413e-a9e3-3e82d944a256'),
('c7f12ba4-a5dc-4523-9f9d-2e65f1115d4b','92b3e227-35be-413e-a9e3-3e82d944a256'),
('ee5548db-b7ac-442a-9dde-08db11678a5d','92b3e227-35be-413e-a9e3-3e82d944a256'),
('f47c353c-364b-4552-b903-b1b5a550401e','92b3e227-35be-413e-a9e3-3e82d944a256');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;

-- 
-- Definition of aspnetusers
-- 

DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(128) NOT NULL,
  `UserName` longtext,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `Discriminator` varchar(128) NOT NULL,
  `FirstName` varchar(45) DEFAULT NULL,
  `LastName` varchar(45) DEFAULT NULL,
  `BirthDate` date DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `Sex` int(11) DEFAULT NULL,
  `JoinDate` datetime DEFAULT NULL,
  `Balance` decimal(10,0) DEFAULT NULL,
  `TariffId` int(11) DEFAULT NULL,
  `Block` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FkUserTariff_idx` (`TariffId`),
  CONSTRAINT `FkUserTariff` FOREIGN KEY (`TariffId`) REFERENCES `tariffs` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=3276 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table aspnetusers
-- 

/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers`(`Id`,`UserName`,`PasswordHash`,`SecurityStamp`,`Discriminator`,`FirstName`,`LastName`,`BirthDate`,`Email`,`Sex`,`JoinDate`,`Balance`,`TariffId`,`Block`) VALUES
('0372a8b7-810c-4054-9be8-7030bcc0d989','Ognev',NULL,NULL,'ApplicationUser','Zair','Olimov','2016-04-14 00:00:00','ramazan.333a@gmail.com',1,'2016-04-14 15:56:13',0,NULL,NULL),
('26562a37-7fe5-4ed4-88a0-c51ce0652aa3','roma','AH1zBBJ+2R86q7ygcrGRE4YBdaFVyWRS07rxomTYdIckVwQ+sFqDQrvI3gS0j+7Wnw==','ebc007f4-6538-4bfc-9a2b-5bde9dd26132','ApplicationUser','не ','выпендривайся','0001-01-01 00:00:00','test@test.com',0,'2016-04-14 15:56:13',0,NULL,NULL),
('30fefa72-6173-4470-acab-225fccc85a95','administrator','AMFI7i5Czoj/eRPZPC2jkJAL8GVDyq042WCYR3A7cKoZaNqIxPaRLnupeEW+hPl67A==','8b7cc426-806b-4f26-b60e-adabefca4938','ApplicationUser','Иван','Белявский','1993-09-17 00:00:00','ivan.belyavskiy@gmail.com',1,'2016-04-28 11:37:46',0,NULL,NULL),
('7d1b1cb6-9a14-455c-bd78-dcad5c115ad1','test','AJq4ZLbECVI2fPrES2VmqSfKFoWKc6ML5KsyBg2IJV3RAeFlPBMh9Gpw0rK1kMWsjg==','8b30a100-561b-4fae-aedd-cf90f908f4e0','ApplicationUser','test','test','0001-01-01 00:00:00','test@test.com',0,'2016-04-30 12:39:26',0,NULL,0),
('891d17ed-78f3-4809-a4cc-3c16d6b552d9','SimpleUser1','APXu8gRtVUS5yBlX7dGG5WffjoC3lMEyq2TcwoEry+fb0REdxorZohdjUDLFmPXLvg==','03adbff0-eacd-4098-9f91-9971be96615f','ApplicationUser','SimpleUserFirstName_1','SimpleUserLastName_2','1994-06-21 00:00:00','ramazan.333a@gmail.com',0,'2016-04-05 00:00:00',0,1,1),
('ac1da694-6aee-4080-8c69-cac3342baada','ramazan','AL1eBAAgCiB+MY8RWKKrFo0ROvR5PtTGgSy8u0htKRtLID2bSxCCWekV4/d41FZM7Q==','d2f47bf0-bfbe-4e94-8b6e-ffd0bf3b23a5','ApplicationUser','Ramazan','Ariskaliev','2016-03-12 00:00:00','ramazan.333a@gmail.com',1,'2016-03-12 00:00:00',0,1,NULL),
('ee5548db-b7ac-442a-9dde-08db11678a5d','test111','AOo7GRTSvUPeOJBLVg8wBPUi1hAubjKeRLUr2+pq4jeo2BThqeQhoblkKOfU5Avkwg==','ce0fe3e0-4098-43d0-861a-1d82fba851d3','ApplicationUser','test111','test11','0001-01-01 00:00:00','test11@test.com',0,'2016-04-30 12:43:56',80000,1,0),
('f47c353c-364b-4552-b903-b1b5a550401e','SimpleUser','AMmHNe+fRUagVjKRHu3IosMCU0xQfHbu4s3mHzNsXrmJwc1S0SWfktGgaZZxFA/jOQ==','81cc66a9-b1af-4567-9fbd-cb5cce418bed','ApplicationUser','SimpleUserFirstName_0','SimpleUserLastName_0','1995-04-08 00:00:00','ramazan.333a@gmail.com',1,'2016-04-05 00:00:00',5000,1,NULL);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;

-- 
-- Definition of banners
-- 

DROP TABLE IF EXISTS `banners`;
CREATE TABLE IF NOT EXISTS `banners` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `start` date DEFAULT NULL,
  `end` date DEFAULT NULL,
  `payment` double DEFAULT NULL,
  `adv_id` int(11) DEFAULT NULL,
  `name` varchar(45) NOT NULL,
  `img_url` varchar(45) NOT NULL,
  `show_amount` int(11) DEFAULT '0',
  `active` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_adv_banner_idx` (`adv_id`),
  CONSTRAINT `fk_adv_banner` FOREIGN KEY (`adv_id`) REFERENCES `advertiser` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=3276 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table banners
-- 

/*!40000 ALTER TABLE `banners` DISABLE KEYS */;
INSERT INTO `banners`(`id`,`start`,`end`,`payment`,`adv_id`,`name`,`img_url`,`show_amount`,`active`) VALUES
(3,'2016-03-11 00:00:00','2016-03-15 00:00:00',18000,4,'banner0001','images (3).jpg',35,NULL),
(4,'2016-03-30 00:00:00','2016-03-31 00:00:00',15000,1,'banner0002','app.jpg',35,1),
(5,'2016-03-10 00:00:00','2016-03-13 00:00:00',12000,1,'banner0003','1523.jpg',35,1),
(6,'2016-03-12 00:00:00','2016-03-13 00:00:00',12500,5,'banner0004','uyvhbjnk.jpg',35,NULL),
(7,'2016-03-29 00:00:00','2016-04-08 00:00:00',0,6,'cinema banner','images25.jpg',35,NULL);
/*!40000 ALTER TABLE `banners` ENABLE KEYS */;

-- 
-- Definition of countries
-- 

DROP TABLE IF EXISTS `countries`;
CREATE TABLE IF NOT EXISTS `countries` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=1638 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table countries
-- 

/*!40000 ALTER TABLE `countries` DISABLE KEYS */;
INSERT INTO `countries`(`id`,`name`) VALUES
(7,'США'),
(8,'Франция'),
(9,'Китай'),
(10,'Россия'),
(11,'Индия'),
(12,'Узбекистан'),
(13,'Великобритания'),
(14,'Италия'),
(15,'Канада'),
(16,'Корея');
/*!40000 ALTER TABLE `countries` ENABLE KEYS */;

-- 
-- Definition of episodehistory
-- 

DROP TABLE IF EXISTS `episodehistory`;
CREATE TABLE IF NOT EXISTS `episodehistory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `episode_id` int(11) NOT NULL,
  `user_id` varchar(255) NOT NULL,
  `watching_date` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_episde_user_idx` (`episode_id`),
  KEY `FkUserEpisodeHistory_idx` (`user_id`),
  CONSTRAINT `FkUserEpisodeHistory` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_episde_user` FOREIGN KEY (`episode_id`) REFERENCES `episodes` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table episodehistory
-- 

/*!40000 ALTER TABLE `episodehistory` DISABLE KEYS */;

/*!40000 ALTER TABLE `episodehistory` ENABLE KEYS */;

-- 
-- Definition of episodes
-- 

DROP TABLE IF EXISTS `episodes`;
CREATE TABLE IF NOT EXISTS `episodes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `url` varchar(45) NOT NULL,
  `season_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_season_episode_idx` (`season_id`),
  CONSTRAINT `fk_season_episode` FOREIGN KEY (`season_id`) REFERENCES `seasons` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=8192 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table episodes
-- 

/*!40000 ALTER TABLE `episodes` DISABLE KEYS */;
INSERT INTO `episodes`(`id`,`name`,`url`,`season_id`) VALUES
(1,'1','2353_3.mp4',1),
(2,'2','2353_3.mp4',1);
/*!40000 ALTER TABLE `episodes` ENABLE KEYS */;

-- 
-- Definition of genres
-- 

DROP TABLE IF EXISTS `genres`;
CREATE TABLE IF NOT EXISTS `genres` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=528 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table genres
-- 

/*!40000 ALTER TABLE `genres` DISABLE KEYS */;
INSERT INTO `genres`(`id`,`name`) VALUES
(33,'аниме'),
(34,'биографический'),
(35,'боевик'),
(36,'вестерн'),
(37,'военный'),
(38,'детектив'),
(39,'детский'),
(40,'документальный'),
(41,'драма'),
(42,'исторический'),
(43,'кинокомикс'),
(44,'комедия'),
(45,'концерт'),
(46,'короткометражный'),
(47,'криминал'),
(48,'мелодрама'),
(49,'мистика'),
(50,'музыка'),
(51,'мультфильм'),
(52,'мюзикл'),
(53,'научный'),
(54,'приключения'),
(55,'реалити-шоу'),
(56,'семейный'),
(57,'спорт'),
(58,'ток-шоу'),
(59,'триллер'),
(60,'ужасы'),
(61,'фантастика'),
(62,'фильм-нуар'),
(63,'фэнтези');
/*!40000 ALTER TABLE `genres` ENABLE KEYS */;

-- 
-- Definition of likes
-- 

DROP TABLE IF EXISTS `likes`;
CREATE TABLE IF NOT EXISTS `likes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` varchar(255) NOT NULL,
  `video_id` int(11) NOT NULL,
  `value` tinyint(1) NOT NULL,
  `creation_date` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `like_video_fk_idx` (`video_id`),
  KEY `FkUserLikes_idx` (`user_id`),
  CONSTRAINT `FkUserLikes` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_like_video` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table likes
-- 

/*!40000 ALTER TABLE `likes` DISABLE KEYS */;

/*!40000 ALTER TABLE `likes` ENABLE KEYS */;

-- 
-- Definition of manufacturer
-- 

DROP TABLE IF EXISTS `manufacturer`;
CREATE TABLE IF NOT EXISTS `manufacturer` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `video_id` int(11) NOT NULL,
  `country_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `country_id_idx` (`country_id`),
  KEY `fk_video_country` (`video_id`),
  CONSTRAINT `fk_country_video` FOREIGN KEY (`country_id`) REFERENCES `countries` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_video_country` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=2730 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table manufacturer
-- 

/*!40000 ALTER TABLE `manufacturer` DISABLE KEYS */;
INSERT INTO `manufacturer`(`id`,`video_id`,`country_id`) VALUES
(1,17,13),
(2,17,14),
(3,18,7),
(4,19,7),
(5,20,7),
(6,20,15);
/*!40000 ALTER TABLE `manufacturer` ENABLE KEYS */;

-- 
-- Definition of moviehistory
-- 

DROP TABLE IF EXISTS `moviehistory`;
CREATE TABLE IF NOT EXISTS `moviehistory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` varchar(255) NOT NULL,
  `movie_id` int(11) NOT NULL,
  `watching_date` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `content_user_fk_idx` (`movie_id`),
  KEY `FkUserMovies_idx` (`user_id`),
  CONSTRAINT `FkUserMovies` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_content_user` FOREIGN KEY (`movie_id`) REFERENCES `movies` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=8192 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table moviehistory
-- 

/*!40000 ALTER TABLE `moviehistory` DISABLE KEYS */;
INSERT INTO `moviehistory`(`id`,`user_id`,`movie_id`,`watching_date`) VALUES
(23,'891d17ed-78f3-4809-a4cc-3c16d6b552d9',4,'2016-04-07 16:05:32'),
(24,'891d17ed-78f3-4809-a4cc-3c16d6b552d9',4,'2016-04-07 16:18:18'),
(25,'891d17ed-78f3-4809-a4cc-3c16d6b552d9',4,'2016-04-09 13:19:13'),
(26,'891d17ed-78f3-4809-a4cc-3c16d6b552d9',4,'2016-04-09 13:19:20'),
(27,'891d17ed-78f3-4809-a4cc-3c16d6b552d9',4,'2016-04-09 13:51:22'),
(28,'891d17ed-78f3-4809-a4cc-3c16d6b552d9',4,'2016-04-09 14:27:42'),
(29,'891d17ed-78f3-4809-a4cc-3c16d6b552d9',4,'2016-04-12 14:24:19'),
(30,'26562a37-7fe5-4ed4-88a0-c51ce0652aa3',8,'2016-04-14 16:08:03'),
(31,'26562a37-7fe5-4ed4-88a0-c51ce0652aa3',8,'2016-04-14 16:08:29'),
(32,'0372a8b7-810c-4054-9be8-7030bcc0d989',6,'2016-04-14 16:08:29'),
(33,'ee5548db-b7ac-442a-9dde-08db11678a5d',9,'2016-04-30 15:32:47');
/*!40000 ALTER TABLE `moviehistory` ENABLE KEYS */;

-- 
-- Definition of movies
-- 

DROP TABLE IF EXISTS `movies`;
CREATE TABLE IF NOT EXISTS `movies` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `url` varchar(200) NOT NULL,
  `creation_date` date NOT NULL,
  `video_id` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `quality` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_content_video1_idx` (`video_id`),
  CONSTRAINT `fk1_content_video` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=2730 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table movies
-- 

/*!40000 ALTER TABLE `movies` DISABLE KEYS */;
INSERT INTO `movies`(`id`,`url`,`creation_date`,`video_id`,`price`,`quality`) VALUES
(4,'http://172.20.16.4/mobile/panda/panda.m3u8','2016-02-29 00:00:00',17,10000.00,1),
(5,'http://172.20.16.4/mobile/pursuit/pursuit_of_happYness.m3u8','2016-02-29 00:00:00',18,8000.00,0),
(6,'http://172.20.16.4/mobile/words/words.m3u8','2016-02-29 00:00:00',19,10000.00,0),
(7,'http://172.20.16.4/mobile/jane/jane.m3u8','1899-12-30 00:00:00',19,8000.00,0),
(8,'http://172.20.16.4/mobile/megamozg/megamind.m3u8','2016-04-01 00:00:00',27,0.00,1),
(9,'http://172.20.16.4/mobile/rapuntzel/rapuntel.m3u8','1899-12-01 00:00:00',28,10000.00,0);
/*!40000 ALTER TABLE `movies` ENABLE KEYS */;

-- 
-- Definition of my_aspnet_applications
-- 

DROP TABLE IF EXISTS `my_aspnet_applications`;
CREATE TABLE IF NOT EXISTS `my_aspnet_applications` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(256) DEFAULT NULL,
  `description` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table my_aspnet_applications
-- 

/*!40000 ALTER TABLE `my_aspnet_applications` DISABLE KEYS */;

/*!40000 ALTER TABLE `my_aspnet_applications` ENABLE KEYS */;

-- 
-- Definition of my_aspnet_membership
-- 

DROP TABLE IF EXISTS `my_aspnet_membership`;
CREATE TABLE IF NOT EXISTS `my_aspnet_membership` (
  `userId` int(11) NOT NULL,
  `Email` varchar(128) DEFAULT NULL,
  `Comment` varchar(255) DEFAULT NULL,
  `Password` varchar(128) NOT NULL,
  `PasswordKey` char(32) DEFAULT NULL,
  `PasswordFormat` tinyint(4) DEFAULT NULL,
  `PasswordQuestion` varchar(255) DEFAULT NULL,
  `PasswordAnswer` varchar(255) DEFAULT NULL,
  `IsApproved` tinyint(1) DEFAULT NULL,
  `LastActivityDate` datetime DEFAULT NULL,
  `LastLoginDate` datetime DEFAULT NULL,
  `LastPasswordChangedDate` datetime DEFAULT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `IsLockedOut` tinyint(1) DEFAULT NULL,
  `LastLockedOutDate` datetime DEFAULT NULL,
  `FailedPasswordAttemptCount` int(10) unsigned DEFAULT NULL,
  `FailedPasswordAttemptWindowStart` datetime DEFAULT NULL,
  `FailedPasswordAnswerAttemptCount` int(10) unsigned DEFAULT NULL,
  `FailedPasswordAnswerAttemptWindowStart` datetime DEFAULT NULL,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC COMMENT='2';

-- 
-- Dumping data for table my_aspnet_membership
-- 

/*!40000 ALTER TABLE `my_aspnet_membership` DISABLE KEYS */;

/*!40000 ALTER TABLE `my_aspnet_membership` ENABLE KEYS */;

-- 
-- Definition of my_aspnet_paths
-- 

DROP TABLE IF EXISTS `my_aspnet_paths`;
CREATE TABLE IF NOT EXISTS `my_aspnet_paths` (
  `applicationId` int(11) NOT NULL,
  `pathId` varchar(36) NOT NULL,
  `path` varchar(256) NOT NULL,
  `loweredPath` varchar(256) NOT NULL,
  PRIMARY KEY (`pathId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table my_aspnet_paths
-- 

/*!40000 ALTER TABLE `my_aspnet_paths` DISABLE KEYS */;

/*!40000 ALTER TABLE `my_aspnet_paths` ENABLE KEYS */;

-- 
-- Definition of my_aspnet_personalizationallusers
-- 

DROP TABLE IF EXISTS `my_aspnet_personalizationallusers`;
CREATE TABLE IF NOT EXISTS `my_aspnet_personalizationallusers` (
  `pathId` varchar(36) NOT NULL,
  `pageSettings` blob NOT NULL,
  `lastUpdatedDate` datetime NOT NULL,
  PRIMARY KEY (`pathId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table my_aspnet_personalizationallusers
-- 

/*!40000 ALTER TABLE `my_aspnet_personalizationallusers` DISABLE KEYS */;

/*!40000 ALTER TABLE `my_aspnet_personalizationallusers` ENABLE KEYS */;

-- 
-- Definition of my_aspnet_personalizationperuser
-- 

DROP TABLE IF EXISTS `my_aspnet_personalizationperuser`;
CREATE TABLE IF NOT EXISTS `my_aspnet_personalizationperuser` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `applicationId` int(11) NOT NULL,
  `pathId` varchar(36) DEFAULT NULL,
  `userId` int(11) DEFAULT NULL,
  `pageSettings` blob NOT NULL,
  `lastUpdatedDate` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table my_aspnet_personalizationperuser
-- 

/*!40000 ALTER TABLE `my_aspnet_personalizationperuser` DISABLE KEYS */;

/*!40000 ALTER TABLE `my_aspnet_personalizationperuser` ENABLE KEYS */;

-- 
-- Definition of my_aspnet_profiles
-- 

DROP TABLE IF EXISTS `my_aspnet_profiles`;
CREATE TABLE IF NOT EXISTS `my_aspnet_profiles` (
  `userId` int(11) NOT NULL,
  `valueindex` longtext,
  `stringdata` longtext,
  `binarydata` longblob,
  `lastUpdatedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table my_aspnet_profiles
-- 

/*!40000 ALTER TABLE `my_aspnet_profiles` DISABLE KEYS */;

/*!40000 ALTER TABLE `my_aspnet_profiles` ENABLE KEYS */;

-- 
-- Definition of my_aspnet_roles
-- 

DROP TABLE IF EXISTS `my_aspnet_roles`;
CREATE TABLE IF NOT EXISTS `my_aspnet_roles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `applicationId` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table my_aspnet_roles
-- 

/*!40000 ALTER TABLE `my_aspnet_roles` DISABLE KEYS */;

/*!40000 ALTER TABLE `my_aspnet_roles` ENABLE KEYS */;

-- 
-- Definition of my_aspnet_schemaversion
-- 

DROP TABLE IF EXISTS `my_aspnet_schemaversion`;
CREATE TABLE IF NOT EXISTS `my_aspnet_schemaversion` (
  `version` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table my_aspnet_schemaversion
-- 

/*!40000 ALTER TABLE `my_aspnet_schemaversion` DISABLE KEYS */;
INSERT INTO `my_aspnet_schemaversion`(`version`) VALUES
(10);
/*!40000 ALTER TABLE `my_aspnet_schemaversion` ENABLE KEYS */;

-- 
-- Definition of my_aspnet_sessioncleanup
-- 

DROP TABLE IF EXISTS `my_aspnet_sessioncleanup`;
CREATE TABLE IF NOT EXISTS `my_aspnet_sessioncleanup` (
  `LastRun` datetime NOT NULL,
  `IntervalMinutes` int(11) NOT NULL,
  `ApplicationId` int(11) NOT NULL,
  PRIMARY KEY (`ApplicationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table my_aspnet_sessioncleanup
-- 

/*!40000 ALTER TABLE `my_aspnet_sessioncleanup` DISABLE KEYS */;

/*!40000 ALTER TABLE `my_aspnet_sessioncleanup` ENABLE KEYS */;

-- 
-- Definition of my_aspnet_sessions
-- 

DROP TABLE IF EXISTS `my_aspnet_sessions`;
CREATE TABLE IF NOT EXISTS `my_aspnet_sessions` (
  `SessionId` varchar(191) NOT NULL,
  `ApplicationId` int(11) NOT NULL,
  `Created` datetime NOT NULL,
  `Expires` datetime NOT NULL,
  `LockDate` datetime NOT NULL,
  `LockId` int(11) NOT NULL,
  `Timeout` int(11) NOT NULL,
  `Locked` tinyint(1) NOT NULL,
  `SessionItems` longblob,
  `Flags` int(11) NOT NULL,
  PRIMARY KEY (`SessionId`,`ApplicationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table my_aspnet_sessions
-- 

/*!40000 ALTER TABLE `my_aspnet_sessions` DISABLE KEYS */;

/*!40000 ALTER TABLE `my_aspnet_sessions` ENABLE KEYS */;

-- 
-- Definition of my_aspnet_sitemap
-- 

DROP TABLE IF EXISTS `my_aspnet_sitemap`;
CREATE TABLE IF NOT EXISTS `my_aspnet_sitemap` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(50) DEFAULT NULL,
  `Description` varchar(512) DEFAULT NULL,
  `Url` varchar(512) DEFAULT NULL,
  `Roles` varchar(1000) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table my_aspnet_sitemap
-- 

/*!40000 ALTER TABLE `my_aspnet_sitemap` DISABLE KEYS */;

/*!40000 ALTER TABLE `my_aspnet_sitemap` ENABLE KEYS */;

-- 
-- Definition of my_aspnet_users
-- 

DROP TABLE IF EXISTS `my_aspnet_users`;
CREATE TABLE IF NOT EXISTS `my_aspnet_users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `applicationId` int(11) NOT NULL,
  `name` varchar(256) NOT NULL,
  `isAnonymous` tinyint(1) NOT NULL DEFAULT '1',
  `lastActivityDate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table my_aspnet_users
-- 

/*!40000 ALTER TABLE `my_aspnet_users` DISABLE KEYS */;

/*!40000 ALTER TABLE `my_aspnet_users` ENABLE KEYS */;

-- 
-- Definition of my_aspnet_usersinroles
-- 

DROP TABLE IF EXISTS `my_aspnet_usersinroles`;
CREATE TABLE IF NOT EXISTS `my_aspnet_usersinroles` (
  `userId` int(11) NOT NULL,
  `roleId` int(11) NOT NULL,
  PRIMARY KEY (`userId`,`roleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table my_aspnet_usersinroles
-- 

/*!40000 ALTER TABLE `my_aspnet_usersinroles` DISABLE KEYS */;

/*!40000 ALTER TABLE `my_aspnet_usersinroles` ENABLE KEYS */;

-- 
-- Definition of overviews
-- 

DROP TABLE IF EXISTS `overviews`;
CREATE TABLE IF NOT EXISTS `overviews` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `comment` mediumtext,
  `video_id` int(11) DEFAULT NULL,
  `user_id` varchar(255) DEFAULT NULL,
  `creation_date` date DEFAULT NULL,
  `rating` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_video_overview_idx` (`video_id`),
  KEY `FkUserOverview_idx` (`user_id`),
  CONSTRAINT `FkUserOverview` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_video_overview` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table overviews
-- 

/*!40000 ALTER TABLE `overviews` DISABLE KEYS */;
INSERT INTO `overviews`(`id`,`comment`,`video_id`,`user_id`,`creation_date`,`rating`) VALUES
(8,'rrrrt',19,'ee5548db-b7ac-442a-9dde-08db11678a5d','2016-04-30 00:00:00',2),
(9,'chvhvhv',19,'ee5548db-b7ac-442a-9dde-08db11678a5d','2016-04-30 00:00:00',2);
/*!40000 ALTER TABLE `overviews` ENABLE KEYS */;

-- 
-- Definition of payments
-- 

DROP TABLE IF EXISTS `payments`;
CREATE TABLE IF NOT EXISTS `payments` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `payment_date` datetime NOT NULL,
  `amount` decimal(10,0) NOT NULL,
  `user_id` varchar(255) NOT NULL,
  `payment_type` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FkUserPayment_idx` (`user_id`),
  CONSTRAINT `FkPaymentUser` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=1489 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table payments
-- 

/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
INSERT INTO `payments`(`id`,`title`,`payment_date`,`amount`,`user_id`,`payment_type`) VALUES
(12,'Пополнение баланса','2016-04-05 00:00:00',20000,'891d17ed-78f3-4809-a4cc-3c16d6b552d9',1),
(13,'Пополнение баланса','2016-04-05 22:12:29',15000,'f47c353c-364b-4552-b903-b1b5a550401e',1),
(14,'Покупка фильма Боги Египта','2016-04-06 05:22:11',10000,'891d17ed-78f3-4809-a4cc-3c16d6b552d9',0),
(15,'Подписка на тариф base','2016-04-06 05:59:40',10000,'f47c353c-364b-4552-b903-b1b5a550401e',0),
(16,'Покупка фильма Рапунцель: Запутанная история','2016-04-12 15:47:51',10000,'891d17ed-78f3-4809-a4cc-3c16d6b552d9',0),
(17,'Покупка фильма Джейн Эйр','2016-04-30 14:03:52',10000,'ee5548db-b7ac-442a-9dde-08db11678a5d',0),
(18,'Подписка на тариф base','2016-04-30 14:04:58',10000,'ee5548db-b7ac-442a-9dde-08db11678a5d',0);
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;

-- 
-- Definition of seasons
-- 

DROP TABLE IF EXISTS `seasons`;
CREATE TABLE IF NOT EXISTS `seasons` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `price` decimal(10,0) NOT NULL,
  `release_date` date DEFAULT NULL,
  `video_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_video_ season_idx` (`video_id`),
  CONSTRAINT `fk_video_ season` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=8192 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table seasons
-- 

/*!40000 ALTER TABLE `seasons` DISABLE KEYS */;
INSERT INTO `seasons`(`id`,`name`,`price`,`release_date`,`video_id`) VALUES
(1,'1',10000,'2009-09-10 00:00:00',18),
(2,'2',10000,NULL,18);
/*!40000 ALTER TABLE `seasons` ENABLE KEYS */;

-- 
-- Definition of statistics_banner
-- 

DROP TABLE IF EXISTS `statistics_banner`;
CREATE TABLE IF NOT EXISTS `statistics_banner` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` date DEFAULT NULL,
  `show_amount` int(11) DEFAULT NULL,
  `id_banner` int(11) DEFAULT NULL,
  `id_user` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_banner_idx` (`id_banner`),
  KEY `id_user_idx` (`id_user`),
  CONSTRAINT `id_banner` FOREIGN KEY (`id_banner`) REFERENCES `banners` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `id_user` FOREIGN KEY (`id_user`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=2340 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table statistics_banner
-- 

/*!40000 ALTER TABLE `statistics_banner` DISABLE KEYS */;
INSERT INTO `statistics_banner`(`id`,`date`,`show_amount`,`id_banner`,`id_user`) VALUES
(8,'2016-04-07 00:00:00',25,3,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(9,'2016-04-07 00:00:00',25,4,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(10,'2016-04-07 00:00:00',25,5,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(11,'2016-04-07 00:00:00',25,6,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(12,'2016-04-07 00:00:00',25,7,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(13,'2016-04-07 00:00:00',26,3,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(14,'2016-04-07 00:00:00',26,4,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(15,'2016-04-07 00:00:00',26,5,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(16,'2016-04-07 00:00:00',26,6,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(17,'2016-04-07 00:00:00',26,7,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(18,'2016-04-09 00:00:00',27,3,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(19,'2016-04-09 00:00:00',27,4,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(20,'2016-04-09 00:00:00',27,5,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(21,'2016-04-09 00:00:00',27,6,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(22,'2016-04-09 00:00:00',27,7,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(23,'2016-04-09 00:00:00',28,3,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(24,'2016-04-09 00:00:00',28,4,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(25,'2016-04-09 00:00:00',28,5,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(26,'2016-04-09 00:00:00',28,6,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(27,'2016-04-09 00:00:00',28,7,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(28,'2016-04-09 00:00:00',29,3,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(29,'2016-04-09 00:00:00',29,4,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(30,'2016-04-09 00:00:00',29,5,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(31,'2016-04-09 00:00:00',29,6,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(32,'2016-04-09 00:00:00',29,7,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(33,'2016-04-09 00:00:00',30,3,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(34,'2016-04-09 00:00:00',30,4,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(35,'2016-04-09 00:00:00',30,5,'891d17ed-78f3-4809-a4cc-3c16d6b552d9'),
(36,'2016-04-14 00:00:00',30,6,'26562a37-7fe5-4ed4-88a0-c51ce0652aa3'),
(37,'2016-04-14 00:00:00',30,7,'26562a37-7fe5-4ed4-88a0-c51ce0652aa3'),
(38,'2016-04-14 00:00:00',31,3,'26562a37-7fe5-4ed4-88a0-c51ce0652aa3'),
(39,'2016-04-14 00:00:00',31,4,'26562a37-7fe5-4ed4-88a0-c51ce0652aa3'),
(40,'2016-04-14 00:00:00',31,5,'26562a37-7fe5-4ed4-88a0-c51ce0652aa3'),
(44,'2016-04-30 00:00:00',32,4,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(45,'2016-04-30 00:00:00',32,5,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(46,'2016-04-30 00:00:00',32,6,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(47,'2016-04-30 00:00:00',32,7,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(48,'2016-04-30 00:00:00',33,3,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(49,'2016-04-30 00:00:00',33,4,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(50,'2016-04-30 00:00:00',33,5,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(51,'2016-04-30 00:00:00',33,6,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(52,'2016-04-30 00:00:00',33,7,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(53,'2016-04-30 00:00:00',34,3,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(54,'2016-04-30 00:00:00',34,4,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(55,'2016-04-30 00:00:00',34,5,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(56,'2016-04-30 00:00:00',34,6,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(57,'2016-04-30 00:00:00',34,7,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(58,'2016-04-30 00:00:00',35,3,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(59,'2016-04-30 00:00:00',35,4,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(60,'2016-04-30 00:00:00',35,5,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(61,'2016-04-30 00:00:00',35,6,'ee5548db-b7ac-442a-9dde-08db11678a5d'),
(62,'2016-04-30 00:00:00',35,7,'ee5548db-b7ac-442a-9dde-08db11678a5d');
/*!40000 ALTER TABLE `statistics_banner` ENABLE KEYS */;

-- 
-- Definition of statistics_teaser
-- 

DROP TABLE IF EXISTS `statistics_teaser`;
CREATE TABLE IF NOT EXISTS `statistics_teaser` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_teasers` int(11) DEFAULT NULL,
  `id_users` varchar(128) DEFAULT NULL,
  `showAmount` int(11) DEFAULT NULL,
  `dateShow` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_teaser_idx` (`id_teasers`),
  KEY `id_user_idx` (`id_users`),
  CONSTRAINT `id_teasers` FOREIGN KEY (`id_teasers`) REFERENCES `teaser` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `id_users` FOREIGN KEY (`id_users`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=442 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table statistics_teaser
-- 

/*!40000 ALTER TABLE `statistics_teaser` DISABLE KEYS */;

/*!40000 ALTER TABLE `statistics_teaser` ENABLE KEYS */;

-- 
-- Definition of subscriptions
-- 

DROP TABLE IF EXISTS `subscriptions`;
CREATE TABLE IF NOT EXISTS `subscriptions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tariff_id` int(11) DEFAULT NULL,
  `start` datetime DEFAULT NULL,
  `end` datetime DEFAULT NULL,
  `payment_id` int(11) NOT NULL,
  `user_id` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `user_tariff_fk_idx` (`tariff_id`),
  KEY `FkSubscriptionPayment_idx` (`payment_id`),
  KEY `FkUserSubscription_idx` (`user_id`),
  CONSTRAINT `FkSubscriptionPayment` FOREIGN KEY (`payment_id`) REFERENCES `payments` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FkUserSubscription` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tariff_user` FOREIGN KEY (`tariff_id`) REFERENCES `tariffs` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=8192 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table subscriptions
-- 

/*!40000 ALTER TABLE `subscriptions` DISABLE KEYS */;
INSERT INTO `subscriptions`(`id`,`tariff_id`,`start`,`end`,`payment_id`,`user_id`) VALUES
(1,1,'2016-04-06 05:59:41','2016-05-06 05:59:41',15,'f47c353c-364b-4552-b903-b1b5a550401e'),
(2,1,'2016-04-30 14:04:59','2016-05-30 14:04:59',18,'ee5548db-b7ac-442a-9dde-08db11678a5d');
/*!40000 ALTER TABLE `subscriptions` ENABLE KEYS */;

-- 
-- Definition of tariffs
-- 

DROP TABLE IF EXISTS `tariffs`;
CREATE TABLE IF NOT EXISTS `tariffs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `description` longtext,
  `creation_date` date DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `adverticement_enabled` tinyint(1) DEFAULT NULL,
  `new_films_enabled` tinyint(1) DEFAULT NULL,
  `active` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table tariffs
-- 

/*!40000 ALTER TABLE `tariffs` DISABLE KEYS */;
INSERT INTO `tariffs`(`id`,`name`,`description`,`creation_date`,`price`,`adverticement_enabled`,`new_films_enabled`,`active`) VALUES
(1,'base','Может возникнуть вопрос, а как быть с _Layout (мастер страницами) – ведь это тоже View и они тоже хотят свои модели. Вполне резонно – ведь мы помним, что view диктует модель, всё остальное следует потом. Поэтому создайте в приложении класс SharedLayoutViewModel с нужными вашему _Layout.cshtml свойствами, и наследуйте от него ваши модели для остальных View. Пользуйтесь Result-фильтрами чтобы наполнять эту модель в одном месте для всех методов ваших контроллеров. Или переопределите OnResultExecuting в базовом классе ваших контроллеров, и делайте это там.','2016-03-12 00:00:00',10000.00,1,1,1);
/*!40000 ALTER TABLE `tariffs` ENABLE KEYS */;

-- 
-- Definition of teaser
-- 

DROP TABLE IF EXISTS `teaser`;
CREATE TABLE IF NOT EXISTS `teaser` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `start` date DEFAULT NULL,
  `end` date DEFAULT NULL,
  `showAmount` int(11) DEFAULT NULL,
  `payment` double DEFAULT NULL,
  `adv_id` int(11) DEFAULT NULL,
  `name` varchar(45) NOT NULL,
  `img_url` varchar(45) NOT NULL,
  `active` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_id_teaser_idx` (`adv_id`),
  CONSTRAINT `fk_id_teaser` FOREIGN KEY (`adv_id`) REFERENCES `advertiser` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=4096 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table teaser
-- 

/*!40000 ALTER TABLE `teaser` DISABLE KEYS */;
INSERT INTO `teaser`(`id`,`start`,`end`,`showAmount`,`payment`,`adv_id`,`name`,`img_url`,`active`) VALUES
(3,'2016-03-31 00:00:00','2016-04-02 00:00:00',9,20000,4,'teaser0001','ca878584ed6edaa80707c29609e66a20.gif',NULL),
(4,'2016-03-31 00:00:00','2016-04-02 00:00:00',9,18000,1,'teaser0002','embarcadero_190x280_till25_5494326.jpg',NULL),
(5,'2016-03-31 00:00:00','2016-04-01 00:00:00',9,15000,1,'teaser0001','130309.gif',NULL),
(6,'2016-03-31 00:00:00','2016-04-01 00:00:00',8,5000,1,'teaser0002','140104.gif',NULL);
/*!40000 ALTER TABLE `teaser` ENABLE KEYS */;

-- 
-- Definition of trailers
-- 

DROP TABLE IF EXISTS `trailers`;
CREATE TABLE IF NOT EXISTS `trailers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `video_id` int(11) NOT NULL,
  `url` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_video_trailer_idx` (`video_id`),
  CONSTRAINT `fk_video_trailer` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=8192 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table trailers
-- 

/*!40000 ALTER TABLE `trailers` DISABLE KEYS */;
INSERT INTO `trailers`(`id`,`title`,`video_id`,`url`) VALUES
(1,'Трейлер к фильму Боги Египта',17,'/uploads/2200_2.mp4'),
(2,'Дневники вампира трейлер сезон 7',18,'/uploads/2288_3.mp4');
/*!40000 ALTER TABLE `trailers` ENABLE KEYS */;

-- 
-- Definition of usermovies
-- 

DROP TABLE IF EXISTS `usermovies`;
CREATE TABLE IF NOT EXISTS `usermovies` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` varchar(255) NOT NULL,
  `movie_id` int(11) NOT NULL,
  `payment_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_purchase_movie_idx` (`movie_id`),
  KEY `FkUserMovies_idx` (`user_id`),
  KEY `FkUserOwnMovies_idx` (`user_id`),
  KEY `FkMoviePayment_idx` (`payment_id`),
  CONSTRAINT `FkMoviePayment` FOREIGN KEY (`payment_id`) REFERENCES `payments` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FkUserOwnMovies` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_purchase_movie` FOREIGN KEY (`movie_id`) REFERENCES `movies` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=8192 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table usermovies
-- 

/*!40000 ALTER TABLE `usermovies` DISABLE KEYS */;
INSERT INTO `usermovies`(`id`,`user_id`,`movie_id`,`payment_id`) VALUES
(1,'891d17ed-78f3-4809-a4cc-3c16d6b552d9',4,14),
(2,'891d17ed-78f3-4809-a4cc-3c16d6b552d9',8,14),
(3,'891d17ed-78f3-4809-a4cc-3c16d6b552d9',9,16),
(4,'0372a8b7-810c-4054-9be8-7030bcc0d989',6,14),
(5,'0372a8b7-810c-4054-9be8-7030bcc0d989',7,14),
(6,'ee5548db-b7ac-442a-9dde-08db11678a5d',6,17);
/*!40000 ALTER TABLE `usermovies` ENABLE KEYS */;

-- 
-- Definition of userseasons
-- 

DROP TABLE IF EXISTS `userseasons`;
CREATE TABLE IF NOT EXISTS `userseasons` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` varchar(255) NOT NULL,
  `season_id` int(11) NOT NULL,
  `payment_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_season_user_idx` (`season_id`),
  KEY `FkUserSeasons_idx` (`user_id`),
  KEY `FkSeasonPayment_idx` (`payment_id`),
  CONSTRAINT `FkSeasonPayment` FOREIGN KEY (`payment_id`) REFERENCES `payments` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FkUserSeasons` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_season_user` FOREIGN KEY (`season_id`) REFERENCES `seasons` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table userseasons
-- 

/*!40000 ALTER TABLE `userseasons` DISABLE KEYS */;

/*!40000 ALTER TABLE `userseasons` ENABLE KEYS */;

-- 
-- Definition of videoactors
-- 

DROP TABLE IF EXISTS `videoactors`;
CREATE TABLE IF NOT EXISTS `videoactors` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `video_id` int(11) NOT NULL,
  `actor_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `video_id_idx` (`video_id`),
  KEY `actor_id_idx` (`actor_id`),
  CONSTRAINT `fk_actor_video` FOREIGN KEY (`actor_id`) REFERENCES `actors` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_video_actor` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=744 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table videoactors
-- 

/*!40000 ALTER TABLE `videoactors` DISABLE KEYS */;
INSERT INTO `videoactors`(`id`,`video_id`,`actor_id`) VALUES
(1,17,14),
(2,17,15),
(3,18,8),
(4,18,9),
(5,18,10),
(6,18,11),
(7,18,12),
(8,18,13),
(9,18,14),
(10,18,15),
(11,18,16),
(12,18,17),
(13,19,8),
(14,19,9),
(15,20,8),
(16,20,9),
(17,20,10),
(18,20,11),
(19,20,14),
(20,20,15),
(21,20,16),
(22,20,17);
/*!40000 ALTER TABLE `videoactors` ENABLE KEYS */;

-- 
-- Definition of videogenres
-- 

DROP TABLE IF EXISTS `videogenres`;
CREATE TABLE IF NOT EXISTS `videogenres` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `video_id` int(11) NOT NULL,
  `genre_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `video_id_idx` (`video_id`),
  KEY `genre_id_idx` (`genre_id`),
  CONSTRAINT `fk_genre_video` FOREIGN KEY (`genre_id`) REFERENCES `genres` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_video_genre` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=59 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=1365 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table videogenres
-- 

/*!40000 ALTER TABLE `videogenres` DISABLE KEYS */;
INSERT INTO `videogenres`(`id`,`video_id`,`genre_id`) VALUES
(47,17,35),
(48,17,59),
(49,17,63),
(50,18,48),
(51,18,49),
(52,18,59),
(53,18,63),
(54,19,41),
(55,19,48),
(56,20,35),
(57,20,61),
(58,20,63);
/*!40000 ALTER TABLE `videogenres` ENABLE KEYS */;

-- 
-- Definition of videos
-- 

DROP TABLE IF EXISTS `videos`;
CREATE TABLE IF NOT EXISTS `videos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `age_limit` int(11) NOT NULL,
  `release_date` date NOT NULL,
  `details` longtext NOT NULL,
  `director` varchar(45) NOT NULL,
  `type` int(2) NOT NULL,
  `img_url` varchar(45) NOT NULL,
  `score` decimal(10,0) DEFAULT NULL,
  `last_score_calc` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=1638 ROW_FORMAT=DYNAMIC;

-- 
-- Dumping data for table videos
-- 

/*!40000 ALTER TABLE `videos` DISABLE KEYS */;
INSERT INTO `videos`(`id`,`name`,`age_limit`,`release_date`,`details`,`director`,`type`,`img_url`,`score`,`last_score_calc`) VALUES
(17,'Боги Египта',16,'2016-02-29 00:00:00','Postpaid — модель расчётов, при которой оператор сначала предоставляет услуги абоненту или агенту в рамках заключённого с ним договора, а потом производит тарификацию и выставление счетов для оплаты. Процесс тарификации и выставления счетов является планово-регулярным и обычно охватывает оговоренный в договоре календарный промежуток времени (чаще всего — месяц, иногда — неделя, квартал, год). Контрагент обязан оплатить сумму выставленного счёта в течение оговоренного в контракте промежутка времени, в случае несвоевременной оплаты к нему применяются указанные в договоре методы работы с должником, в рамках процессов взыскания дебиторской задолженности.','Рамазан Арыскалиев',0,'gods_of_egypt.jpg',NULL,NULL),
(18,'Дневники вампира',16,'2009-09-10 00:00:00','Действие происходит в Мистик-Фоллс, вымышленном маленьком городке штата Вирджиния, который преследуют сверхъестественные существа. Сериал рассказывает о жизни Елены Гилберт (Нина Добрев), 17-летней девушки, которая влюбляется в 162-летнего вампира по имени Стефан Сальваторе (Пол Уэсли). Их отношения становятся все более сложными, когда порочный старший брат Стефана Дэймон Сальваторе (Иэн Сомерхолдер) возвращается, чтобы посеять хаос в городе и отомстить своему младшему брату. Оба брата влюбляются в Елену в основном из-за её сходства с их прошлой любовью Кэтрин Пирс. Оказывается, что Елена является двойником Кэтрин, которая в конечном итоге возвращается с серьёзными планами по отношению к трио.','Кевин Уильямсон',1,'dnevniki-vampira.png',NULL,NULL),
(19,'Джейн Эйр',0,'2014-01-01 00:00:00','bfkjebf','fewf',0,'The-Sky-is-the-Limit.mpg',NULL,NULL),
(22,'В погоне за счастьем',0,'2006-12-15 00:00:00','Крис Гарднер — отец одиночка. Воспитывая пятилетнего сына, Крис изо всех сил старается сделать так, чтобы ребенок рос счастливым. Работая продавцом, он не может оплатить квартиру, и их выселяют. Оказавшись на улице, но не желая сдаваться, отец устраивается стажером в брокерскую компанию, рассчитывая получить должность специалиста. Только на протяжении стажировки он не будет получать никаких денег, а стажировка длится 6 месяцев...','Габриэле Муччино',0,'1419755573_poster-104938.jpg',NULL,NULL),
(23,'Игры разума',0,'2001-12-13 00:00:00','От всемирной известности до греховных глубин — все это познал на своей шкуре Джон Форбс Нэш-младший. Математический гений, он на заре своей карьеры сделал титаническую работу в области теории игр, которая перевернула этот раздел математики и практически принесла ему международную известность.  Однако буквально в то же время заносчивый и пользующийся успехом у женщин Нэш получает удар судьбы, который переворачивает уже его собственную жизнь.','Рон Ховард',0,'1438872246_poster-530.jpg',NULL,NULL),
(24,'Kung Fu Panda',0,'2008-05-15 00:00:00','Спасение Долины Мира и всех ее обитателей от непобедимого и безжалостного мастера Тай Лунга должно лечь на плечи Воина Дракона, Избранного среди лучших из лучших, коим становится... неуклюжий, ленивый и вечно голодный панда По.  Ему предстоит долгий и трудный путь к вершинам мастерства кунг-фу бок о бок с легендарными воинами: Тигрой, Обезьяной, Богомолом, Гадюкой и Журавлем. По постигнет тайну древнего Свитка и станет Воином Дракона только в том случае, если сможет поверить в себя...','Марк Осборн, Джон Стивенсон',0,'1454472363_poster-103734.jpg',NULL,NULL),
(25,'Кунг-фу Панда 2',0,'2011-05-22 00:00:00','Панда По наконец-то исполнит свою мечту, станет Воином Дракона и со своими друзьями и мастерами кунг-фу — Неистовой Пятеркой — защитит Великую Долину от страшного злодея и его легиона...','Дженнифер Ю',0,'1436188788_poster-427878.jpg',NULL,NULL),
(26,'Слова',0,'2012-01-27 00:00:00','Рори Джэнсен — писатель, который наконец обретает долгожданную известность, но его роман-бестселлер оказывается написан другим человеком, которому он теперь должен заплатить высокую цену за украденные у него жизнь и работу.','Брайан Клагман, Ли Стернтал',0,'1400069225_poster-580639.jpg',NULL,NULL),
(27,'Мегамозг',0,'2010-10-28 00:00:00','Мегамозг — самый гениальный и самый неудачливый злодей в мире. Вот уже много лет он пытается покорить Метро-Сити самыми разнообразными способами. Но каждая такая попытка кончается провалом по вине супергероя по имени Метро-Мэн. Но злодей убивает супергероя, и внезапно Мегамозг лишается цели в жизни. Суперзлодей без супергероя.  Единственный выход — создать нового супергероя, которого он называет Титаном. Но Титан решает, что быть злодеем куда интереснее. Вот только ему не хочется править миром, он желает его уничтожить. Мегамозгу предстоит непростой выбор. Сможет ли злой гений стать героем — спасителем человечества.','Том МакГрат',0,'1414778569_poster-405608.jpg',NULL,NULL),
(28,'Рапунцель: Запутанная история',0,'2010-10-25 00:00:00','Обаятельный разбойник Флинн путешествует по жизни с легкостью, лишь потому, что он красив, болтлив и удачлив. И, казалось, фортуна всегда на его стороне, пока однажды он не выбирает высокую башню в густой чаще леса в качестве «спокойного» убежища. Флинн оказывается связанным по рукам и ногам юной красавицей по имени Рапунцель.   Если вы думаете, что самое интересное в ней — это 21 метр волшебных золотистых волос, то вы заблуждаетесь! Запертая в башне и отчаянно ищущая приключений, Рапунцель решает использовать Флинна в качестве билета в большой мир. Сначала комичное похищение, затем невинный шантаж — и вот наши герои на воле. Вместе с главными героями в авантюрное путешествие отправятся бравый конь-ищейка Максимус, ручной хамелеон и шайка сумасбродных разбойников.','Нэйтан Грено, Байрон Ховард',0,'1402333764_poster-84049.jpg',NULL,NULL);
/*!40000 ALTER TABLE `videos` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2016-05-02 16:25:46
-- Total time: 0:0:0:1:295 (d:h:m:s:ms)
