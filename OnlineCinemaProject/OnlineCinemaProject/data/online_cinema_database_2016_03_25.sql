-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: onlinecinema
-- ------------------------------------------------------
-- Server version	5.7.10-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__migrationhistory`
--

DROP TABLE IF EXISTS `__migrationhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__migrationhistory` (
  `MigrationId` varchar(100) NOT NULL,
  `ContextKey` varchar(200) NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`,`ContextKey`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__migrationhistory`
--

LOCK TABLES `__migrationhistory` WRITE;
/*!40000 ALTER TABLE `__migrationhistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__migrationhistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `actors`
--

DROP TABLE IF EXISTS `actors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `actors` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actors`
--

LOCK TABLES `actors` WRITE;
/*!40000 ALTER TABLE `actors` DISABLE KEYS */;
INSERT INTO `actors` VALUES (8,'Актер1'),(9,'Актер2'),(10,'Актер3'),(11,'Актер4'),(12,'Актер5'),(13,'Актер6'),(14,'Актер7'),(15,'Актер8'),(16,'Актер9'),(17,'Актер10');
/*!40000 ALTER TABLE `actors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `advertiser`
--

DROP TABLE IF EXISTS `advertiser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `advertiser` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `phone_number` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `advertiser`
--

LOCK TABLES `advertiser` WRITE;
/*!40000 ALTER TABLE `advertiser` DISABLE KEYS */;
INSERT INTO `advertiser` VALUES (1,'cocacola','coca@mail.ru','+998935718543'),(3,'M&Ms','mandms@mail.ru','+998935718545'),(4,'Alpen Gold','gold@inbox.ru','+998979999999'),(5,'sarkor','support@sarkor.uz','+998711220000');
/*!40000 ALTER TABLE `advertiser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(128) NOT NULL,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('1a6d70ef-2b86-48da-b36c-b974855a8783','BilingManager'),('4d5f7e37-2498-40db-9891-ea998b599671','ContentManager'),('4de2ec91-cce0-46e3-8723-cbea20461ef4','Admin'),('6fc8922c-be46-445f-aa95-d3b7a7fd9145','PRManager'),('92b3e227-35be-413e-a9e3-3e82d944a256','User');
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  `User_Id` varchar(128) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`),
  KEY `User_Id` (`User_Id`),
  CONSTRAINT `IdentityUserClaim_User` FOREIGN KEY (`User_Id`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserlogins` (
  `UserId` varchar(128) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`ProviderKey`),
  CONSTRAINT `IdentityUserLogin_User` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(128) NOT NULL,
  `RoleId` varchar(128) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IdentityUserRole_Role` (`RoleId`),
  CONSTRAINT `IdentityUserRole_Role` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `IdentityUserRole_User` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` VALUES ('ac1da694-6aee-4080-8c69-cac3342baada','1a6d70ef-2b86-48da-b36c-b974855a8783'),('ac1da694-6aee-4080-8c69-cac3342baada','4d5f7e37-2498-40db-9891-ea998b599671'),('9e0cc9f5-0665-49d4-a009-4c859a00b2d9','4de2ec91-cce0-46e3-8723-cbea20461ef4'),('ac1da694-6aee-4080-8c69-cac3342baada','4de2ec91-cce0-46e3-8723-cbea20461ef4'),('d2027e6f-e136-4737-b197-cf9811d1142f','4de2ec91-cce0-46e3-8723-cbea20461ef4'),('c2e50aec-ab00-493c-9fec-1770fe663d4b','6fc8922c-be46-445f-aa95-d3b7a7fd9145'),('a9fe59b2-8d88-4bef-87f3-a081bcce6632','92b3e227-35be-413e-a9e3-3e82d944a256'),('ac1da694-6aee-4080-8c69-cac3342baada','92b3e227-35be-413e-a9e3-3e82d944a256'),('c2e50aec-ab00-493c-9fec-1770fe663d4b','92b3e227-35be-413e-a9e3-3e82d944a256'),('c7f12ba4-a5dc-4523-9f9d-2e65f1115d4b','92b3e227-35be-413e-a9e3-3e82d944a256'),('d2027e6f-e136-4737-b197-cf9811d1142f','92b3e227-35be-413e-a9e3-3e82d944a256');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetusers` (
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
  `JoinDate` date DEFAULT NULL,
  `Balance` decimal(10,0) DEFAULT NULL,
  `SubscriptionId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FkUserSubscriptions_idx` (`SubscriptionId`),
  CONSTRAINT `FkUserSubscriptions` FOREIGN KEY (`SubscriptionId`) REFERENCES `subscriptions` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('9e0cc9f5-0665-49d4-a009-4c859a00b2d9','superadmin','AMHSa9fgWdM1KwSdYnpXZw+AAw/1mpihcw3yYEMJxXEiT4wcVfSoQkNJhSek1DvHdA==','e87ba6bd-245a-4a0f-988a-59a21d4ac88d','ApplicationUser',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('a9fe59b2-8d88-4bef-87f3-a081bcce6632','Sevilya','ABwVr9/SPXxkDG5WUoUDWgCSzjqolei4I1mh2XQ7tEl5WPR0YLaXyUFuca4jNN6Vow==','deae39bc-8277-475a-bd24-c6cefc92db45','ApplicationUser',NULL,NULL,NULL,NULL,NULL,NULL,10000,NULL),('ac1da694-6aee-4080-8c69-cac3342baada','ramazan','AL1eBAAgCiB+MY8RWKKrFo0ROvR5PtTGgSy8u0htKRtLID2bSxCCWekV4/d41FZM7Q==','d2f47bf0-bfbe-4e94-8b6e-ffd0bf3b23a5','ApplicationUser','Ramazan','Ariskaliev','2016-03-12','ramazan.333a@gmail.com',1,'2016-03-12',60001,2),('c2e50aec-ab00-493c-9fec-1770fe663d4b','Lilya','AOtUDYH2JhafovH0UVyWv4jP0uomgDVcWn9tp8NUnDFeC0fx8lGyecdn5pZMkDYvXQ==','8c1782a7-0f7c-4224-bf4e-9df18193fc6e','ApplicationUser',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('c7f12ba4-a5dc-4523-9f9d-2e65f1115d4b','user1','AMgzuX5sUnJezjsVjtli1aR2/+esboa2LYRuz4Zzf4ms9mfiB/g4JD4gupoWJA8eFQ==','20b670a3-9536-4339-a632-b328638fda12','ApplicationUser',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('d2027e6f-e136-4737-b197-cf9811d1142f','vanya','AC+l409lxW4ebEpZbHSJPi8ZqF19fNbNiWD0mgrqAAHW61Um+Oo16CvsIM5/juWJyQ==','7d8c779d-ad79-4005-a8e3-6edc01a0c884','ApplicationUser',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `banners`
--

DROP TABLE IF EXISTS `banners`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `banners` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `start` date NOT NULL,
  `end` date NOT NULL,
  `payment` double NOT NULL,
  `adv_id` int(11) NOT NULL,
  `name` varchar(45) NOT NULL,
  `img_url` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_adv_banner_idx` (`adv_id`),
  CONSTRAINT `fk_adv_banner` FOREIGN KEY (`adv_id`) REFERENCES `advertiser` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `banners`
--

LOCK TABLES `banners` WRITE;
/*!40000 ALTER TABLE `banners` DISABLE KEYS */;
INSERT INTO `banners` VALUES (3,'2016-03-11','2016-03-15',18000,4,'banner0001','images (3).jpg'),(4,'2016-03-10','2016-03-13',15000,3,'banner0002','images.jpg'),(5,'2016-03-10','2016-03-13',12000,1,'banner0003','1523.jpg'),(6,'2016-03-12','2016-03-13',12500,5,'banner0004','uyvhbjnk.jpg');
/*!40000 ALTER TABLE `banners` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `countries`
--

DROP TABLE IF EXISTS `countries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `countries` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `countries`
--

LOCK TABLES `countries` WRITE;
/*!40000 ALTER TABLE `countries` DISABLE KEYS */;
INSERT INTO `countries` VALUES (7,'США'),(8,'Франция'),(9,'Китай'),(10,'Россия'),(11,'Индия'),(12,'Узбекистан'),(13,'Великобритания'),(14,'Италия'),(15,'Канада'),(16,'Корея');
/*!40000 ALTER TABLE `countries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `episodehistory`
--

DROP TABLE IF EXISTS `episodehistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `episodehistory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `episode_id` int(11) NOT NULL,
  `user_id` varchar(255) NOT NULL,
  `watching_date` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_episde_user_idx` (`episode_id`),
  KEY `FkUserEpisodeHistory_idx` (`user_id`),
  CONSTRAINT `FkUserEpisodeHistory` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_episde_user` FOREIGN KEY (`episode_id`) REFERENCES `episodes` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `episodehistory`
--

LOCK TABLES `episodehistory` WRITE;
/*!40000 ALTER TABLE `episodehistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `episodehistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `episodes`
--

DROP TABLE IF EXISTS `episodes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `episodes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `url` varchar(45) NOT NULL,
  `season_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_season_episode_idx` (`season_id`),
  CONSTRAINT `fk_season_episode` FOREIGN KEY (`season_id`) REFERENCES `seasons` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `episodes`
--

LOCK TABLES `episodes` WRITE;
/*!40000 ALTER TABLE `episodes` DISABLE KEYS */;
INSERT INTO `episodes` VALUES (1,'1','2353_3.mp4',1),(2,'2','2353_3.mp4',1);
/*!40000 ALTER TABLE `episodes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `genres`
--

DROP TABLE IF EXISTS `genres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `genres` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genres`
--

LOCK TABLES `genres` WRITE;
/*!40000 ALTER TABLE `genres` DISABLE KEYS */;
INSERT INTO `genres` VALUES (33,'аниме'),(34,'биографический'),(35,'боевик'),(36,'вестерн'),(37,'военный'),(38,'детектив'),(39,'детский'),(40,'документальный'),(41,'драма'),(42,'исторический'),(43,'кинокомикс'),(44,'комедия'),(45,'концерт'),(46,'короткометражный'),(47,'криминал'),(48,'мелодрама'),(49,'мистика'),(50,'музыка'),(51,'мультфильм'),(52,'мюзикл'),(53,'научный'),(54,'приключения'),(55,'реалити-шоу'),(56,'семейный'),(57,'спорт'),(58,'ток-шоу'),(59,'триллер'),(60,'ужасы'),(61,'фантастика'),(62,'фильм-нуар'),(63,'фэнтези');
/*!40000 ALTER TABLE `genres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `likes`
--

DROP TABLE IF EXISTS `likes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `likes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` varchar(255) NOT NULL,
  `video_id` int(11) NOT NULL,
  `like` tinyint(1) NOT NULL,
  `creation_date` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `like_video_fk_idx` (`video_id`),
  KEY `FkUserLikes_idx` (`user_id`),
  CONSTRAINT `FkUserLikes` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_like_video` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `likes`
--

LOCK TABLES `likes` WRITE;
/*!40000 ALTER TABLE `likes` DISABLE KEYS */;
/*!40000 ALTER TABLE `likes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `manufacturer`
--

DROP TABLE IF EXISTS `manufacturer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `manufacturer` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `video_id` int(11) NOT NULL,
  `country_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `country_id_idx` (`country_id`),
  KEY `fk_video_country` (`video_id`),
  CONSTRAINT `fk_country_video` FOREIGN KEY (`country_id`) REFERENCES `countries` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_video_country` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manufacturer`
--

LOCK TABLES `manufacturer` WRITE;
/*!40000 ALTER TABLE `manufacturer` DISABLE KEYS */;
INSERT INTO `manufacturer` VALUES (1,17,13),(2,17,14),(3,18,7),(4,19,7),(5,20,7),(6,20,15);
/*!40000 ALTER TABLE `manufacturer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `moviehistory`
--

DROP TABLE IF EXISTS `moviehistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `moviehistory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` varchar(255) NOT NULL,
  `movie_id` int(11) NOT NULL,
  `watching_date` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `content_user_fk_idx` (`movie_id`),
  KEY `FkUserMovies_idx` (`user_id`),
  CONSTRAINT `FkUserMovies` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_content_user` FOREIGN KEY (`movie_id`) REFERENCES `movies` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `moviehistory`
--

LOCK TABLES `moviehistory` WRITE;
/*!40000 ALTER TABLE `moviehistory` DISABLE KEYS */;
INSERT INTO `moviehistory` VALUES (1,'ac1da694-6aee-4080-8c69-cac3342baada',4,'2016-03-24'),(2,'ac1da694-6aee-4080-8c69-cac3342baada',4,'2016-03-25');
/*!40000 ALTER TABLE `moviehistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movies`
--

DROP TABLE IF EXISTS `movies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `movies` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `url` varchar(200) NOT NULL,
  `creation_date` date NOT NULL,
  `video_id` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `quality` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_content_video1_idx` (`video_id`),
  CONSTRAINT `fk1_content_video` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movies`
--

LOCK TABLES `movies` WRITE;
/*!40000 ALTER TABLE `movies` DISABLE KEYS */;
INSERT INTO `movies` VALUES (4,'http://10.42.0.100/mobile/panda/panda.m3u8','2016-02-29',17,10000.00,1),(5,'http://10.42.0.100/mobile/pursuit/pursuit_of_happYness.m3u8','2016-02-29',18,8000.00,0),(6,'http://10.42.0.100/mobile/words/words.m3u8','2016-02-29',19,10000.00,0);
/*!40000 ALTER TABLE `movies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `my_aspnet_applications`
--

DROP TABLE IF EXISTS `my_aspnet_applications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `my_aspnet_applications` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(256) DEFAULT NULL,
  `description` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `my_aspnet_applications`
--

LOCK TABLES `my_aspnet_applications` WRITE;
/*!40000 ALTER TABLE `my_aspnet_applications` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_applications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `my_aspnet_membership`
--

DROP TABLE IF EXISTS `my_aspnet_membership`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `my_aspnet_membership` (
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='2';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `my_aspnet_membership`
--

LOCK TABLES `my_aspnet_membership` WRITE;
/*!40000 ALTER TABLE `my_aspnet_membership` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_membership` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `my_aspnet_paths`
--

DROP TABLE IF EXISTS `my_aspnet_paths`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `my_aspnet_paths` (
  `applicationId` int(11) NOT NULL,
  `pathId` varchar(36) NOT NULL,
  `path` varchar(256) NOT NULL,
  `loweredPath` varchar(256) NOT NULL,
  PRIMARY KEY (`pathId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `my_aspnet_paths`
--

LOCK TABLES `my_aspnet_paths` WRITE;
/*!40000 ALTER TABLE `my_aspnet_paths` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_paths` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `my_aspnet_personalizationallusers`
--

DROP TABLE IF EXISTS `my_aspnet_personalizationallusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `my_aspnet_personalizationallusers` (
  `pathId` varchar(36) NOT NULL,
  `pageSettings` blob NOT NULL,
  `lastUpdatedDate` datetime NOT NULL,
  PRIMARY KEY (`pathId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `my_aspnet_personalizationallusers`
--

LOCK TABLES `my_aspnet_personalizationallusers` WRITE;
/*!40000 ALTER TABLE `my_aspnet_personalizationallusers` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_personalizationallusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `my_aspnet_personalizationperuser`
--

DROP TABLE IF EXISTS `my_aspnet_personalizationperuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `my_aspnet_personalizationperuser` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `applicationId` int(11) NOT NULL,
  `pathId` varchar(36) DEFAULT NULL,
  `userId` int(11) DEFAULT NULL,
  `pageSettings` blob NOT NULL,
  `lastUpdatedDate` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `my_aspnet_personalizationperuser`
--

LOCK TABLES `my_aspnet_personalizationperuser` WRITE;
/*!40000 ALTER TABLE `my_aspnet_personalizationperuser` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_personalizationperuser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `my_aspnet_profiles`
--

DROP TABLE IF EXISTS `my_aspnet_profiles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `my_aspnet_profiles` (
  `userId` int(11) NOT NULL,
  `valueindex` longtext,
  `stringdata` longtext,
  `binarydata` longblob,
  `lastUpdatedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `my_aspnet_profiles`
--

LOCK TABLES `my_aspnet_profiles` WRITE;
/*!40000 ALTER TABLE `my_aspnet_profiles` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_profiles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `my_aspnet_roles`
--

DROP TABLE IF EXISTS `my_aspnet_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `my_aspnet_roles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `applicationId` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `my_aspnet_roles`
--

LOCK TABLES `my_aspnet_roles` WRITE;
/*!40000 ALTER TABLE `my_aspnet_roles` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `my_aspnet_schemaversion`
--

DROP TABLE IF EXISTS `my_aspnet_schemaversion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `my_aspnet_schemaversion` (
  `version` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `my_aspnet_schemaversion`
--

LOCK TABLES `my_aspnet_schemaversion` WRITE;
/*!40000 ALTER TABLE `my_aspnet_schemaversion` DISABLE KEYS */;
INSERT INTO `my_aspnet_schemaversion` VALUES (10);
/*!40000 ALTER TABLE `my_aspnet_schemaversion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `my_aspnet_sessioncleanup`
--

DROP TABLE IF EXISTS `my_aspnet_sessioncleanup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `my_aspnet_sessioncleanup` (
  `LastRun` datetime NOT NULL,
  `IntervalMinutes` int(11) NOT NULL,
  `ApplicationId` int(11) NOT NULL,
  PRIMARY KEY (`ApplicationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `my_aspnet_sessioncleanup`
--

LOCK TABLES `my_aspnet_sessioncleanup` WRITE;
/*!40000 ALTER TABLE `my_aspnet_sessioncleanup` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_sessioncleanup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `my_aspnet_sessions`
--

DROP TABLE IF EXISTS `my_aspnet_sessions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `my_aspnet_sessions` (
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `my_aspnet_sessions`
--

LOCK TABLES `my_aspnet_sessions` WRITE;
/*!40000 ALTER TABLE `my_aspnet_sessions` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_sessions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `my_aspnet_sitemap`
--

DROP TABLE IF EXISTS `my_aspnet_sitemap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `my_aspnet_sitemap` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(50) DEFAULT NULL,
  `Description` varchar(512) DEFAULT NULL,
  `Url` varchar(512) DEFAULT NULL,
  `Roles` varchar(1000) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `my_aspnet_sitemap`
--

LOCK TABLES `my_aspnet_sitemap` WRITE;
/*!40000 ALTER TABLE `my_aspnet_sitemap` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_sitemap` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `my_aspnet_users`
--

DROP TABLE IF EXISTS `my_aspnet_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `my_aspnet_users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `applicationId` int(11) NOT NULL,
  `name` varchar(256) NOT NULL,
  `isAnonymous` tinyint(1) NOT NULL DEFAULT '1',
  `lastActivityDate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `my_aspnet_users`
--

LOCK TABLES `my_aspnet_users` WRITE;
/*!40000 ALTER TABLE `my_aspnet_users` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `my_aspnet_usersinroles`
--

DROP TABLE IF EXISTS `my_aspnet_usersinroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `my_aspnet_usersinroles` (
  `userId` int(11) NOT NULL,
  `roleId` int(11) NOT NULL,
  PRIMARY KEY (`userId`,`roleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `my_aspnet_usersinroles`
--

LOCK TABLES `my_aspnet_usersinroles` WRITE;
/*!40000 ALTER TABLE `my_aspnet_usersinroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_usersinroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `overviews`
--

DROP TABLE IF EXISTS `overviews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `overviews` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `text` mediumtext,
  `video_id` int(11) NOT NULL,
  `user_id` varchar(255) NOT NULL,
  `creation_date` date NOT NULL,
  `rating` float NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_video_overview_idx` (`video_id`),
  KEY `FkUserOverview_idx` (`user_id`),
  CONSTRAINT `FkUserOverview` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_video_overview` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `overviews`
--

LOCK TABLES `overviews` WRITE;
/*!40000 ALTER TABLE `overviews` DISABLE KEYS */;
/*!40000 ALTER TABLE `overviews` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payments` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `payment_date` date NOT NULL,
  `amount` decimal(10,0) NOT NULL,
  `user_id` varchar(255) NOT NULL,
  `payment` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FkUserPayment_idx` (`user_id`),
  CONSTRAINT `FkUserPayment` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
INSERT INTO `payments` VALUES (1,'Пополнение баланса','2016-03-09',10000,'a9fe59b2-8d88-4bef-87f3-a081bcce6632',0),(2,'Покупка фильма Боги Египта','2016-03-15',10000,'ac1da694-6aee-4080-8c69-cac3342baada',0),(3,'Покупка сезона1, сериалаДневники вампира','2016-03-16',10000,'ac1da694-6aee-4080-8c69-cac3342baada',0),(4,'Подписка на тариф base','2016-03-16',10000,'ac1da694-6aee-4080-8c69-cac3342baada',0),(5,'test1','2016-03-24',2000,'ac1da694-6aee-4080-8c69-cac3342baada',0),(6,'test2','2016-03-24',6000,'a9fe59b2-8d88-4bef-87f3-a081bcce6632',0),(7,'test3','2016-03-24',8000,'a9fe59b2-8d88-4bef-87f3-a081bcce6632',0);
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seasons`
--

DROP TABLE IF EXISTS `seasons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `seasons` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `price` decimal(10,0) NOT NULL,
  `release_date` date DEFAULT NULL,
  `video_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_video_ season_idx` (`video_id`),
  CONSTRAINT `fk_video_ season` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seasons`
--

LOCK TABLES `seasons` WRITE;
/*!40000 ALTER TABLE `seasons` DISABLE KEYS */;
INSERT INTO `seasons` VALUES (1,'1',10000,'2009-09-10',18),(2,'2',10000,NULL,18);
/*!40000 ALTER TABLE `seasons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subscriptions`
--

DROP TABLE IF EXISTS `subscriptions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subscriptions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tariff_id` int(11) NOT NULL,
  `start` date NOT NULL,
  `end` date NOT NULL,
  `payment_id` int(11) NOT NULL,
  `enabled` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_tariff_fk_idx` (`tariff_id`),
  KEY `FkSubscriptionPayment_idx` (`payment_id`),
  CONSTRAINT `FkPaymentSubscription` FOREIGN KEY (`payment_id`) REFERENCES `payments` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tariff_user` FOREIGN KEY (`tariff_id`) REFERENCES `tariffs` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subscriptions`
--

LOCK TABLES `subscriptions` WRITE;
/*!40000 ALTER TABLE `subscriptions` DISABLE KEYS */;
INSERT INTO `subscriptions` VALUES (1,1,'2016-03-12','2016-03-12',10000,0),(2,1,'2016-03-16','2016-04-16',4,0);
/*!40000 ALTER TABLE `subscriptions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tariffs`
--

DROP TABLE IF EXISTS `tariffs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tariffs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` longtext NOT NULL,
  `creation_date` date NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `adverticement_enabled` tinyint(1) NOT NULL,
  `new_films_enabled` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tariffs`
--

LOCK TABLES `tariffs` WRITE;
/*!40000 ALTER TABLE `tariffs` DISABLE KEYS */;
INSERT INTO `tariffs` VALUES (1,'base','base','2016-03-12',10000.00,1,1);
/*!40000 ALTER TABLE `tariffs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teaser`
--

DROP TABLE IF EXISTS `teaser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `teaser` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `start` date NOT NULL,
  `end` date NOT NULL,
  `showAmount` int(11) NOT NULL,
  `payment` double NOT NULL,
  `adv_id` int(11) NOT NULL,
  `name` varchar(45) NOT NULL,
  `img_url` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_id_teaser_idx` (`adv_id`),
  CONSTRAINT `fk_id_teaser` FOREIGN KEY (`adv_id`) REFERENCES `advertiser` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teaser`
--

LOCK TABLES `teaser` WRITE;
/*!40000 ALTER TABLE `teaser` DISABLE KEYS */;
INSERT INTO `teaser` VALUES (3,'2016-03-11','2016-03-14',4,20000,4,'teaser0001','images (4).jpg'),(4,'2016-03-10','2016-03-12',3,18000,1,'teaser0002','images (2).jpg');
/*!40000 ALTER TABLE `teaser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trailers`
--

DROP TABLE IF EXISTS `trailers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trailers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `video_id` int(11) NOT NULL,
  `url` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_video_trailer_idx` (`video_id`),
  CONSTRAINT `fk_video_trailer` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trailers`
--

LOCK TABLES `trailers` WRITE;
/*!40000 ALTER TABLE `trailers` DISABLE KEYS */;
INSERT INTO `trailers` VALUES (1,'Трейлер к фильму Боги Египта',17,'/uploads/2200_2.mp4'),(2,'Дневники вампира трейлер сезон 7',18,'/uploads/2288_3.mp4');
/*!40000 ALTER TABLE `trailers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usermovies`
--

DROP TABLE IF EXISTS `usermovies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usermovies` (
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usermovies`
--

LOCK TABLES `usermovies` WRITE;
/*!40000 ALTER TABLE `usermovies` DISABLE KEYS */;
INSERT INTO `usermovies` VALUES (1,'ac1da694-6aee-4080-8c69-cac3342baada',4,10000),(2,'ac1da694-6aee-4080-8c69-cac3342baada',4,2);
/*!40000 ALTER TABLE `usermovies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userseasons`
--

DROP TABLE IF EXISTS `userseasons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userseasons` (
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userseasons`
--

LOCK TABLES `userseasons` WRITE;
/*!40000 ALTER TABLE `userseasons` DISABLE KEYS */;
INSERT INTO `userseasons` VALUES (1,'ac1da694-6aee-4080-8c69-cac3342baada',1,3);
/*!40000 ALTER TABLE `userseasons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `videoactors`
--

DROP TABLE IF EXISTS `videoactors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `videoactors` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `video_id` int(11) NOT NULL,
  `actor_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `video_id_idx` (`video_id`),
  KEY `actor_id_idx` (`actor_id`),
  CONSTRAINT `fk_actor_video` FOREIGN KEY (`actor_id`) REFERENCES `actors` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_video_actor` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `videoactors`
--

LOCK TABLES `videoactors` WRITE;
/*!40000 ALTER TABLE `videoactors` DISABLE KEYS */;
INSERT INTO `videoactors` VALUES (1,17,14),(2,17,15),(3,18,8),(4,18,9),(5,18,10),(6,18,11),(7,18,12),(8,18,13),(9,18,14),(10,18,15),(11,18,16),(12,18,17),(13,19,8),(14,19,9),(15,20,8),(16,20,9),(17,20,10),(18,20,11),(19,20,14),(20,20,15),(21,20,16),(22,20,17);
/*!40000 ALTER TABLE `videoactors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `videogenres`
--

DROP TABLE IF EXISTS `videogenres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `videogenres` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `video_id` int(11) NOT NULL,
  `genre_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `video_id_idx` (`video_id`),
  KEY `genre_id_idx` (`genre_id`),
  CONSTRAINT `fk_genre_video` FOREIGN KEY (`genre_id`) REFERENCES `genres` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_video_genre` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=59 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `videogenres`
--

LOCK TABLES `videogenres` WRITE;
/*!40000 ALTER TABLE `videogenres` DISABLE KEYS */;
INSERT INTO `videogenres` VALUES (47,17,35),(48,17,59),(49,17,63),(50,18,48),(51,18,49),(52,18,59),(53,18,63),(54,19,41),(55,19,48),(56,20,35),(57,20,61),(58,20,63);
/*!40000 ALTER TABLE `videogenres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `videos`
--

DROP TABLE IF EXISTS `videos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `videos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `age_limit` int(11) NOT NULL,
  `release_date` date NOT NULL,
  `details` longtext NOT NULL,
  `director` varchar(45) NOT NULL,
  `type` int(2) NOT NULL,
  `img_url` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `videos`
--

LOCK TABLES `videos` WRITE;
/*!40000 ALTER TABLE `videos` DISABLE KEYS */;
INSERT INTO `videos` VALUES (17,'Боги Египта',16,'2016-02-29','Postpaid — модель расчётов, при которой оператор сначала предоставляет услуги абоненту или агенту в рамках заключённого с ним договора, а потом производит тарификацию и выставление счетов для оплаты. Процесс тарификации и выставления счетов является планово-регулярным и обычно охватывает оговоренный в договоре календарный промежуток времени (чаще всего — месяц, иногда — неделя, квартал, год). Контрагент обязан оплатить сумму выставленного счёта в течение оговоренного в контракте промежутка времени, в случае несвоевременной оплаты к нему применяются указанные в договоре методы работы с должником, в рамках процессов взыскания дебиторской задолженности.','Рамазан Арыскалиев',0,'gods_of_egypt.jpg'),(18,'Дневники вампира',16,'2009-09-10','Действие происходит в Мистик-Фоллс, вымышленном маленьком городке штата Вирджиния, который преследуют сверхъестественные существа. Сериал рассказывает о жизни Елены Гилберт (Нина Добрев), 17-летней девушки, которая влюбляется в 162-летнего вампира по имени Стефан Сальваторе (Пол Уэсли). Их отношения становятся все более сложными, когда порочный старший брат Стефана Дэймон Сальваторе (Иэн Сомерхолдер) возвращается, чтобы посеять хаос в городе и отомстить своему младшему брату. Оба брата влюбляются в Елену в основном из-за её сходства с их прошлой любовью Кэтрин Пирс. Оказывается, что Елена является двойником Кэтрин, которая в конечном итоге возвращается с серьёзными планами по отношению к трио.','Кевин Уильямсон',1,'dnevniki-vampira.png'),(19,'Тhe sky',0,'2014-01-01','bfkjebf','fewf',0,'The-Sky-is-the-Limit.mpg'),(21,'Кунг-фу Панда 3',0,'2016-01-23','Воссоединившись со своим давно потерянным отцом, По отправляется в тайный рай для панд, где его ожидает встреча с множеством веселых сородичей. Однако вскоре злодей Кай начинает зачистку — он уничтожает кунг-фу мастеров по всему Китаю.  По предстоит сделать невозможное — обучить боевому искусству деревню, полную его веселых, неуклюжих собратьев, и тем самым превратить их в отряд кунг-фу панд.','Алессандро Карлони, Дженнифер Ю',0,'1454350562_poster-692865.jpg'),(22,'В погоне за счастьем',0,'2006-12-15','Крис Гарднер — отец одиночка. Воспитывая пятилетнего сына, Крис изо всех сил старается сделать так, чтобы ребенок рос счастливым. Работая продавцом, он не может оплатить квартиру, и их выселяют. Оказавшись на улице, но не желая сдаваться, отец устраивается стажером в брокерскую компанию, рассчитывая получить должность специалиста. Только на протяжении стажировки он не будет получать никаких денег, а стажировка длится 6 месяцев...','Габриэле Муччино',0,'1419755573_poster-104938.jpg'),(23,'Игры разума',0,'2001-12-13','От всемирной известности до греховных глубин — все это познал на своей шкуре Джон Форбс Нэш-младший. Математический гений, он на заре своей карьеры сделал титаническую работу в области теории игр, которая перевернула этот раздел математики и практически принесла ему международную известность.  Однако буквально в то же время заносчивый и пользующийся успехом у женщин Нэш получает удар судьбы, который переворачивает уже его собственную жизнь.','Рон Ховард',0,'1438872246_poster-530.jpg'),(24,'Kung Fu Panda',0,'2008-05-15','Спасение Долины Мира и всех ее обитателей от непобедимого и безжалостного мастера Тай Лунга должно лечь на плечи Воина Дракона, Избранного среди лучших из лучших, коим становится... неуклюжий, ленивый и вечно голодный панда По.  Ему предстоит долгий и трудный путь к вершинам мастерства кунг-фу бок о бок с легендарными воинами: Тигрой, Обезьяной, Богомолом, Гадюкой и Журавлем. По постигнет тайну древнего Свитка и станет Воином Дракона только в том случае, если сможет поверить в себя...','Марк Осборн, Джон Стивенсон',0,'1454472363_poster-103734.jpg'),(25,'Кунг-фу Панда 2',0,'2011-05-22','Панда По наконец-то исполнит свою мечту, станет Воином Дракона и со своими друзьями и мастерами кунг-фу — Неистовой Пятеркой — защитит Великую Долину от страшного злодея и его легиона...','Дженнифер Ю',0,'1436188788_poster-427878.jpg'),(26,'Слова',0,'2012-01-27','Рори Джэнсен — писатель, который наконец обретает долгожданную известность, но его роман-бестселлер оказывается написан другим человеком, которому он теперь должен заплатить высокую цену за украденные у него жизнь и работу.','Брайан Клагман, Ли Стернтал',0,'1400069225_poster-580639.jpg'),(27,'Мегамозг',0,'2010-10-28','Мегамозг — самый гениальный и самый неудачливый злодей в мире. Вот уже много лет он пытается покорить Метро-Сити самыми разнообразными способами. Но каждая такая попытка кончается провалом по вине супергероя по имени Метро-Мэн. Но злодей убивает супергероя, и внезапно Мегамозг лишается цели в жизни. Суперзлодей без супергероя.  Единственный выход — создать нового супергероя, которого он называет Титаном. Но Титан решает, что быть злодеем куда интереснее. Вот только ему не хочется править миром, он желает его уничтожить. Мегамозгу предстоит непростой выбор. Сможет ли злой гений стать героем — спасителем человечества.','Том МакГрат',0,'1414778569_poster-405608.jpg'),(28,'Рапунцель: Запутанная история',0,'2010-10-25','Обаятельный разбойник Флинн путешествует по жизни с легкостью, лишь потому, что он красив, болтлив и удачлив. И, казалось, фортуна всегда на его стороне, пока однажды он не выбирает высокую башню в густой чаще леса в качестве «спокойного» убежища. Флинн оказывается связанным по рукам и ногам юной красавицей по имени Рапунцель.   Если вы думаете, что самое интересное в ней — это 21 метр волшебных золотистых волос, то вы заблуждаетесь! Запертая в башне и отчаянно ищущая приключений, Рапунцель решает использовать Флинна в качестве билета в большой мир. Сначала комичное похищение, затем невинный шантаж — и вот наши герои на воле. Вместе с главными героями в авантюрное путешествие отправятся бравый конь-ищейка Максимус, ручной хамелеон и шайка сумасбродных разбойников.','Нэйтан Грено, Байрон Ховард',0,'1402333764_poster-84049.jpg');
/*!40000 ALTER TABLE `videos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-03-25 23:51:29
