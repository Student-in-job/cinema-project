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
INSERT INTO `__migrationhistory` VALUES ('201603081223203_InitialCreate','OnlineCinemaProject.Migrations.Configuration','ã\0\0\0\0\0\0\›\\\€n\‹6}/\–Ù\‘\»\ vP4\rv8kª5\Z\€A\÷\…k@K\‹5[äREÆc[˙I˝Öí∫Kºà\“j/\ŒCå]i83ú9\ﬁ\Œ\Êø˛ùæ}±Û\0ä\"2sè\'GÆâà¨f\Óö-_ºrﬂæ˘˛ª\Èy>:üπóBé∑$t\Ê\ﬁ3øˆ<\Í\ﬂ\√\–Ià¸$¢—íM¸(Ù@y\'GGøz\«\«\‰*\\Æ\Àq¶◊Ñ°¶_¯\◊yD|≥5¿WQ\01ÕüÛ7ãT´s\rBHc\‡√ô{C0\"p\ŒˇÖ\‡C˝	}6\…Zπ\Œ)FÄ{¥Äx\È:Äêà\∆˝}˝â\¬K\"≤Z\ƒ¸¿∑O1\‰rKÄ)\Ã˚Ò∫∑\Ì\“—â\ËíW5∑\Ï,\Ô\Ó9{\Ó•]ûπóL}å0¨Kr\Ÿ?\‡S\„\ƒ\„√ÑK\√e\Ÿ\ﬁuºf;Ø›∞lVk#\\\‡Åd	«Å\Î\\Å\«˜ê¨\ÿ=G\»\…+◊π@è0(û\‰Q¸Dá\roƒí5ˇzΩ\∆\‹aXæ˜å6\≈_ÉU˛qs´SØ\nØ1\Ëßqåëü¶î#\'qùwÄ\¬\‹7≠Iëî\Ï•gï@!;\«\0Öª\œ\‚%a/O±©\rêã¯$0\0c0!ïÛ]\ŸK;&åçêBKü^o¡\‘5x@´4-£Yû?Búæ§˜(V\0!ı\ÏK&zëD°±äÙß_\—:ÒE\"£\ÿ-HVê\rDq•\ﬂp\È˝©|ò\r}\0î~çí\‡w@\Ô∑nl˝u¬≥∑` åwàı}t\\¥0\Ó@{1(l]}≠\Èv53∫ZI]≠âıuU(\ÎˆTH-å~VR*7’è¥\ÎCäàh,•hjÉ?~@A{Z’¥(Ñπ\'˝KU\·ŸÆ\ÀU´õª6ﬂà\Ÿ÷ço6•ˆ\Zπ¶)U1¿7CW\‰=FÑ01d\ﬁ¥˜´4)Ve6ì4î\ŸÙè	Tïî\nSÉø\«d\–\Èeo\‰üR\Z˘(uO7|Q¨+\œI\‡\ÿ\rRıf*õfú´5fHl¡¯\„ô˚ì\ÿN3\Â\Ï®€≥5-ª\Ì±xC\Œ Ü:ß~v\"0\‘ÅåDø†˘Ñ_ò[\0\œyrYaÚXG\ƒG1¿V˝hµ∂\\≠\ÔJ;\Ì7g0ÜDµ óç⁄∫Êï∂Z°\Îä\‘‘´¡\–ù\’∂Açb¨´Aìåa–îKÖ¬à\ ¿a!S\Í∆éÅ)\Â\ ∆æz\›.≠ã¶¢∫o	óœøbJ\›\ÿ.ümΩ¨m\Âm0£:\≈RÉ&;\ÓM\’Ò¡Æ±©\rh∂h\‚I`<0ëèç\œ\Ó\ƒK¯»§êäÜ»ö\Á\’\"L9\'Hk*ë\¬f\“XKLµ]\Z{)+\Œmå\ZÛ•`µ]±¨äeKi-\…áÛµxMÿºcmÉ\–zm\\ˆQ5©^XØÜ5ä%ù\r\ÿsÒû—™mØ\Ã¡\“,\‘z,\’4= ë`)yqVS´T5FÄl–§Y1ÙX3å†} ©~\»léîn\Î3ãi:UTT\À`)\Ê≠¢U\Ï\”\À)ß∫!˜≤+Ú\‚*\›\”‹•OØ@#≤™›≠\ÁOúEv±>±\ËÅf:<ü*\Ó±KoKK,J¿\n∂\ﬁr\”\‹\”îPv∏\‚\ƒgÑíXü	∂0Yüg\ÂSE!->g-Ù4É\Ê\‰,/ır]ºß°X/¶w´\n®õ;ÇÛ\00H7kÛØC¢_æ\Í[g˜cıˆ\ŸY\√\‘k˘/-O•®Ik®f\n¨\‘#%™}è?<W\Í\Ê\Áäc8@\È≤<Ω\“V0\Íj\Œı\"∏ó\€\»]G§/©¯|≥¸¡bl\Ô<ºÄ+[[Ú\0©û\⁄kj\ﬁ◊µ5\ﬂ\ÿkl]\◊U∂^\Ìñ(8<H£Æπì\Ÿ\Èê°\\\Êî-§N¡W\Íù?çé\Ìå\‰\Z©Æ§ˆ∏ßÆúi$)Àü$Úç\‚†`Ù∆ÉFá©6∑1°;9\”ki›π◊ïu∞Ù:\ÈçRØg%B∂≤\ZVﬂâ˜\∆GøUÒ8(Æ\ÍZt\◊\€O`s\ÿQ˜Û\›Ò∞“û7\Ó]æ\≈\÷W™€¶-∞C´‚ü™Püë\◊<\Ïúˆ∞~Ã§˜´Ω∑ó3/mÒ\€\"%\Ó ≠~kK?Õ∑\◊\›ziøùâ∏NQªf\Ó\’\”\‚o<\Ô\'\È\«9F<àï\ƒ h	)ªç˛Çd\Ê˛<˘•Eø@Ö˜(\r!Û\·\…H¸{ê»§ñ\r\Ë\Ó8\‚z\ƒI\∆H\Ïı˝Ú~GQµˇ“ái(kw®.%)w®≤\÷\ﬁb£\r«û~éÄD\È¸¡AO¥Hø@ö˘C5ï≥\◊\Ó3˚\Õ\”uG´2J6\Óh\⁄d\€]\¬\‡\ŸPTGxìÅ:r¨G%E\Óájc∏+ﬁîîπ1ãg/4\«\ÁE’±ß6f˜\Ô˚`\Í\Ôê7§∞m0\Õ\…\ƒ\÷ia\ﬂ2EÒêJÿæÒµèfçØÉ©_=©Üá∞ú3∑\’Ò\ŸALw§∆ò\Ê¨ntêµ äùõD\"\—å´éí∫(ò\Ÿ\Ÿ\Ã\r\Ó\"Çl\ÈxJ\„k\»\‘1ù±ΩZc˘Å¨÷òö7d2ñ#\”h1ó1õUÛ†∫âûv<O≥m5˜±ì\rjE5[VgwüåQ-ü¨5\‘\Ã3}î\–zÜebUr£ë\'˘\\»üõ\„b◊°\ÿ\"ΩsÛ`4\Í¶\ÊZl+¸M˘áœîµˇ.â\œ\◊≠*Ç\ŒB†ﬂò#KôK≤åäπ∫\ÂQ!\“:AπÇ|=MZüÒ\◊>§4˝%oNó9\Ô`pIn\÷,^3\ﬁe\ﬁ\·∆âûòÚMˆSíj\”\Á\ÈMú˛vå.p7\Ôº!\Ô\÷•\ﬂä£ç\n±ñ\»OßE.ô8•^=ïöÆ#b©(_π∫Öaåπ2zC\‡\Í}\Îéa3b\”3V	iÆ£jœør¯\·\„õˇ	K\0\0','6.0.0-20911');
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
INSERT INTO `actors` VALUES (8,'–ê–∫—Ç–µ—Ä1'),(9,'–ê–∫—Ç–µ—Ä2'),(10,'–ê–∫—Ç–µ—Ä3'),(11,'–ê–∫—Ç–µ—Ä4'),(12,'–ê–∫—Ç–µ—Ä5'),(13,'–ê–∫—Ç–µ—Ä6'),(14,'–ê–∫—Ç–µ—Ä7'),(15,'–ê–∫—Ç–µ—Ä8'),(16,'–ê–∫—Ç–µ—Ä9'),(17,'–ê–∫—Ç–µ—Ä10');
/*!40000 ALTER TABLE `actors` ENABLE KEYS */;
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
INSERT INTO `aspnetuserroles` VALUES ('9e0cc9f5-0665-49d4-a009-4c859a00b2d9','4de2ec91-cce0-46e3-8723-cbea20461ef4'),('d2027e6f-e136-4737-b197-cf9811d1142f','4de2ec91-cce0-46e3-8723-cbea20461ef4'),('c2e50aec-ab00-493c-9fec-1770fe663d4b','6fc8922c-be46-445f-aa95-d3b7a7fd9145'),('a9fe59b2-8d88-4bef-87f3-a081bcce6632','92b3e227-35be-413e-a9e3-3e82d944a256'),('c2e50aec-ab00-493c-9fec-1770fe663d4b','92b3e227-35be-413e-a9e3-3e82d944a256'),('c7f12ba4-a5dc-4523-9f9d-2e65f1115d4b','92b3e227-35be-413e-a9e3-3e82d944a256'),('d2027e6f-e136-4737-b197-cf9811d1142f','92b3e227-35be-413e-a9e3-3e82d944a256');
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
INSERT INTO `aspnetusers` VALUES ('9e0cc9f5-0665-49d4-a009-4c859a00b2d9','superadmin','AMHSa9fgWdM1KwSdYnpXZw+AAw/1mpihcw3yYEMJxXEiT4wcVfSoQkNJhSek1DvHdA==','e87ba6bd-245a-4a0f-988a-59a21d4ac88d','ApplicationUser',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('a9fe59b2-8d88-4bef-87f3-a081bcce6632','Sevilya','ABwVr9/SPXxkDG5WUoUDWgCSzjqolei4I1mh2XQ7tEl5WPR0YLaXyUFuca4jNN6Vow==','deae39bc-8277-475a-bd24-c6cefc92db45','ApplicationUser',NULL,NULL,NULL,NULL,NULL,NULL,10000,NULL),('c2e50aec-ab00-493c-9fec-1770fe663d4b','Lilya','AOtUDYH2JhafovH0UVyWv4jP0uomgDVcWn9tp8NUnDFeC0fx8lGyecdn5pZMkDYvXQ==','8c1782a7-0f7c-4224-bf4e-9df18193fc6e','ApplicationUser',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('c7f12ba4-a5dc-4523-9f9d-2e65f1115d4b','user1','AMgzuX5sUnJezjsVjtli1aR2/+esboa2LYRuz4Zzf4ms9mfiB/g4JD4gupoWJA8eFQ==','20b670a3-9536-4339-a632-b328638fda12','ApplicationUser',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('d2027e6f-e136-4737-b197-cf9811d1142f','vanya','AC+l409lxW4ebEpZbHSJPi8ZqF19fNbNiWD0mgrqAAHW61Um+Oo16CvsIM5/juWJyQ==','7d8c779d-ad79-4005-a8e3-6edc01a0c884','ApplicationUser',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
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
INSERT INTO `countries` VALUES (7,'–°–®–ê'),(8,'–§—Ä–∞–Ω—Ü–∏—è'),(9,'–ö–∏—Ç–∞–π'),(10,'–†–æ—Å—Å–∏—è'),(11,'–ò–Ω–¥–∏—è'),(12,'–£–∑–±–µ–∫–∏—Å—Ç–∞–Ω'),(13,'–í–µ–ª–∏–∫–æ–±—Ä–∏—Ç–∞–Ω–∏—è'),(14,'–ò—Ç–∞–ª–∏—è'),(15,'–ö–∞–Ω–∞–¥–∞'),(16,'–ö–æ—Ä–µ—è');
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
  `watching_date` varchar(45) DEFAULT NULL,
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
INSERT INTO `genres` VALUES (33,'–∞–Ω–∏–º–µ'),(34,'–±–∏–æ–≥—Ä–∞—Ñ–∏—á–µ—Å–∫–∏–π'),(35,'–±–æ–µ–≤–∏–∫'),(36,'–≤–µ—Å—Ç–µ—Ä–Ω'),(37,'–≤–æ–µ–Ω–Ω—ã–π'),(38,'–¥–µ—Ç–µ–∫—Ç–∏–≤'),(39,'–¥–µ—Ç—Å–∫–∏–π'),(40,'–¥–æ–∫—É–º–µ–Ω—Ç–∞–ª—å–Ω—ã–π'),(41,'–¥—Ä–∞–º–∞'),(42,'–∏—Å—Ç–æ—Ä–∏—á–µ—Å–∫–∏–π'),(43,'–∫–∏–Ω–æ–∫–æ–º–∏–∫—Å'),(44,'–∫–æ–º–µ–¥–∏—è'),(45,'–∫–æ–Ω—Ü–µ—Ä—Ç'),(46,'–∫–æ—Ä–æ—Ç–∫–æ–º–µ—Ç—Ä–∞–∂–Ω—ã–π'),(47,'–∫—Ä–∏–º–∏–Ω–∞–ª'),(48,'–º–µ–ª–æ–¥—Ä–∞–º–∞'),(49,'–º–∏—Å—Ç–∏–∫–∞'),(50,'–º—É–∑—ã–∫–∞'),(51,'–º—É–ª—å—Ç—Ñ–∏–ª—å–º'),(52,'–º—é–∑–∏–∫–ª'),(53,'–Ω–∞—É—á–Ω—ã–π'),(54,'–ø—Ä–∏–∫–ª—é—á–µ–Ω–∏—è'),(55,'—Ä–µ–∞–ª–∏—Ç–∏-—à–æ—É'),(56,'—Å–µ–º–µ–π–Ω—ã–π'),(57,'—Å–ø–æ—Ä—Ç'),(58,'—Ç–æ–∫-—à–æ—É'),(59,'—Ç—Ä–∏–ª–ª–µ—Ä'),(60,'—É–∂–∞—Å—ã'),(61,'—Ñ–∞–Ω—Ç–∞—Å—Ç–∏–∫–∞'),(62,'—Ñ–∏–ª—å–º-–Ω—É–∞—Ä'),(63,'—Ñ—ç–Ω—Ç–µ–∑–∏');
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manufacturer`
--

LOCK TABLES `manufacturer` WRITE;
/*!40000 ALTER TABLE `manufacturer` DISABLE KEYS */;
INSERT INTO `manufacturer` VALUES (1,17,13),(2,17,14),(3,18,7);
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
  `content_id` int(11) NOT NULL,
  `watching_date` date NOT NULL,
  `payment` float NOT NULL,
  PRIMARY KEY (`id`),
  KEY `content_user_fk_idx` (`content_id`),
  KEY `FkUserMovies_idx` (`user_id`),
  CONSTRAINT `FkUserMovies` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_content_user` FOREIGN KEY (`content_id`) REFERENCES `movies` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `moviehistory`
--

LOCK TABLES `moviehistory` WRITE;
/*!40000 ALTER TABLE `moviehistory` DISABLE KEYS */;
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
  `url` varchar(45) NOT NULL,
  `creation_date` date NOT NULL,
  `video_id` int(11) NOT NULL,
  `price` float NOT NULL,
  `quality` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_content_video1_idx` (`video_id`),
  CONSTRAINT `fk1_content_video` FOREIGN KEY (`video_id`) REFERENCES `videos` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movies`
--

LOCK TABLES `movies` WRITE;
/*!40000 ALTER TABLE `movies` DISABLE KEYS */;
INSERT INTO `movies` VALUES (4,'2353_3.mp4','2016-02-29',17,10000,1);
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
  `amount` float NOT NULL,
  `user_id` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FkUserPayment_idx` (`user_id`),
  CONSTRAINT `FkUserPayment` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
INSERT INTO `payments` VALUES (1,'–ü–æ–ø–æ–ª–Ω–µ–Ω–∏–µ –±–∞–ª–∞–Ω—Å–∞','2016-03-09',10000,'a9fe59b2-8d88-4bef-87f3-a081bcce6632');
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
  `payment` double NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_tariff_fk_idx` (`tariff_id`),
  CONSTRAINT `fk_tariff_user` FOREIGN KEY (`tariff_id`) REFERENCES `tariffs` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subscriptions`
--

LOCK TABLES `subscriptions` WRITE;
/*!40000 ALTER TABLE `subscriptions` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tariffs`
--

LOCK TABLES `tariffs` WRITE;
/*!40000 ALTER TABLE `tariffs` DISABLE KEYS */;
/*!40000 ALTER TABLE `tariffs` ENABLE KEYS */;
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
INSERT INTO `trailers` VALUES (1,'–¢—Ä–µ–π–ª–µ—Ä –∫ —Ñ–∏–ª—å–º—É –ë–æ–≥–∏ –ï–≥–∏–ø—Ç–∞',17,'/uploads/2200_2.mp4'),(2,'–î–Ω–µ–≤–Ω–∏–∫–∏ –≤–∞–º–ø–∏—Ä–∞ —Ç—Ä–µ–π–ª–µ—Ä —Å–µ–∑–æ–Ω 7',18,'/uploads/2288_3.mp4');
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
  `movie_id` int(11) DEFAULT NULL,
  `payment` decimal(10,0) NOT NULL,
  `purchase_date` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_purchase_movie_idx` (`movie_id`),
  KEY `FkUserMovies_idx` (`user_id`),
  KEY `FkUserOwnMovies_idx` (`user_id`),
  CONSTRAINT `FkUserOwnMovies` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_purchase_movie` FOREIGN KEY (`movie_id`) REFERENCES `movies` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usermovies`
--

LOCK TABLES `usermovies` WRITE;
/*!40000 ALTER TABLE `usermovies` DISABLE KEYS */;
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
  `payment` decimal(10,0) NOT NULL,
  `purchase_date` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_season_user_idx` (`season_id`),
  KEY `FkUserSeasons_idx` (`user_id`),
  CONSTRAINT `FkUserSeasons` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_season_user` FOREIGN KEY (`season_id`) REFERENCES `seasons` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userseasons`
--

LOCK TABLES `userseasons` WRITE;
/*!40000 ALTER TABLE `userseasons` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `videoactors`
--

LOCK TABLES `videoactors` WRITE;
/*!40000 ALTER TABLE `videoactors` DISABLE KEYS */;
INSERT INTO `videoactors` VALUES (1,17,14),(2,17,15),(3,18,8),(4,18,9),(5,18,10),(6,18,11),(7,18,12),(8,18,13),(9,18,14),(10,18,15),(11,18,16),(12,18,17);
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
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `videogenres`
--

LOCK TABLES `videogenres` WRITE;
/*!40000 ALTER TABLE `videogenres` DISABLE KEYS */;
INSERT INTO `videogenres` VALUES (47,17,35),(48,17,59),(49,17,63),(50,18,48),(51,18,49),(52,18,59),(53,18,63);
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
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `videos`
--

LOCK TABLES `videos` WRITE;
/*!40000 ALTER TABLE `videos` DISABLE KEYS */;
INSERT INTO `videos` VALUES (17,'–ë–æ–≥–∏ –ï–≥–∏–ø—Ç–∞',16,'2016-02-29','Postpaid ‚Äî –º–æ–¥–µ–ª—å —Ä–∞—Å—á—ë—Ç–æ–≤, –ø—Ä–∏ –∫–æ—Ç–æ—Ä–æ–π –æ–ø–µ—Ä–∞—Ç–æ—Ä —Å–Ω–∞—á–∞–ª–∞ –ø—Ä–µ–¥–æ—Å—Ç–∞–≤–ª—è–µ—Ç —É—Å–ª—É–≥–∏ –∞–±–æ–Ω–µ–Ω—Ç—É –∏–ª–∏ –∞–≥–µ–Ω—Ç—É –≤ —Ä–∞–º–∫–∞—Ö –∑–∞–∫–ª—é—á—ë–Ω–Ω–æ–≥–æ —Å –Ω–∏–º –¥–æ–≥–æ–≤–æ—Ä–∞, –∞ –ø–æ—Ç–æ–º –ø—Ä–æ–∏–∑–≤–æ–¥–∏—Ç —Ç–∞—Ä–∏—Ñ–∏–∫–∞—Ü–∏—é –∏ –≤—ã—Å—Ç–∞–≤–ª–µ–Ω–∏–µ —Å—á–µ—Ç–æ–≤ –¥–ª—è –æ–ø–ª–∞—Ç—ã. –ü—Ä–æ—Ü–µ—Å—Å —Ç–∞—Ä–∏—Ñ–∏–∫–∞—Ü–∏–∏ –∏ –≤—ã—Å—Ç–∞–≤–ª–µ–Ω–∏—è —Å—á–µ—Ç–æ–≤ —è–≤–ª—è–µ—Ç—Å—è –ø–ª–∞–Ω–æ–≤–æ-—Ä–µ–≥—É–ª—è—Ä–Ω—ã–º –∏ –æ–±—ã—á–Ω–æ –æ—Ö–≤–∞—Ç—ã–≤–∞–µ—Ç –æ–≥–æ–≤–æ—Ä–µ–Ω–Ω—ã–π –≤ –¥–æ–≥–æ–≤–æ—Ä–µ –∫–∞–ª–µ–Ω–¥–∞—Ä–Ω—ã–π –ø—Ä–æ–º–µ–∂—É—Ç–æ–∫ –≤—Ä–µ–º–µ–Ω–∏ (—á–∞—â–µ –≤—Å–µ–≥–æ ‚Äî –º–µ—Å—è—Ü, –∏–Ω–æ–≥–¥–∞ ‚Äî –Ω–µ–¥–µ–ª—è, –∫–≤–∞—Ä—Ç–∞–ª, –≥–æ–¥). –ö–æ–Ω—Ç—Ä–∞–≥–µ–Ω—Ç –æ–±—è–∑–∞–Ω –æ–ø–ª–∞—Ç–∏—Ç—å —Å—É–º–º—É –≤—ã—Å—Ç–∞–≤–ª–µ–Ω–Ω–æ–≥–æ —Å—á—ë—Ç–∞ –≤ —Ç–µ—á–µ–Ω–∏–µ –æ–≥–æ–≤–æ—Ä–µ–Ω–Ω–æ–≥–æ –≤ –∫–æ–Ω—Ç—Ä–∞–∫—Ç–µ –ø—Ä–æ–º–µ–∂—É—Ç–∫–∞ –≤—Ä–µ–º–µ–Ω–∏, –≤ —Å–ª—É—á–∞–µ –Ω–µ—Å–≤–æ–µ–≤—Ä–µ–º–µ–Ω–Ω–æ–π –æ–ø–ª–∞—Ç—ã –∫ –Ω–µ–º—É –ø—Ä–∏–º–µ–Ω—è—é—Ç—Å—è —É–∫–∞–∑–∞–Ω–Ω—ã–µ –≤ –¥–æ–≥–æ–≤–æ—Ä–µ –º–µ—Ç–æ–¥—ã —Ä–∞–±–æ—Ç—ã —Å –¥–æ–ª–∂–Ω–∏–∫–æ–º, –≤ —Ä–∞–º–∫–∞—Ö –ø—Ä–æ—Ü–µ—Å—Å–æ–≤ –≤–∑—ã—Å–∫–∞–Ω–∏—è –¥–µ–±–∏—Ç–æ—Ä—Å–∫–æ–π –∑–∞–¥–æ–ª–∂–µ–Ω–Ω–æ—Å—Ç–∏.','–†–∞–º–∞–∑–∞–Ω –ê—Ä—ã—Å–∫–∞–ª–∏–µ–≤',0,'gods_of_egypt.jpg'),(18,'–î–Ω–µ–≤–Ω–∏–∫–∏ –≤–∞–º–ø–∏—Ä–∞',16,'2009-09-10','–î–µ–π—Å—Ç–≤–∏–µ –ø—Ä–æ–∏—Å—Ö–æ–¥–∏—Ç –≤ –ú–∏—Å—Ç–∏–∫-–§–æ–ª–ª—Å, –≤—ã–º—ã—à–ª–µ–Ω–Ω–æ–º –º–∞–ª–µ–Ω—å–∫–æ–º –≥–æ—Ä–æ–¥–∫–µ —à—Ç–∞—Ç–∞ –í–∏—Ä–¥–∂–∏–Ω–∏—è, –∫–æ—Ç–æ—Ä—ã–π –ø—Ä–µ—Å–ª–µ–¥—É—é—Ç —Å–≤–µ—Ä—Ö—ä–µ—Å—Ç–µ—Å—Ç–≤–µ–Ω–Ω—ã–µ —Å—É—â–µ—Å—Ç–≤–∞. –°–µ—Ä–∏–∞–ª —Ä–∞—Å—Å–∫–∞–∑—ã–≤–∞–µ—Ç –æ –∂–∏–∑–Ω–∏ –ï–ª–µ–Ω—ã –ì–∏–ª–±–µ—Ä—Ç (–ù–∏–Ω–∞ –î–æ–±—Ä–µ–≤), 17-–ª–µ—Ç–Ω–µ–π –¥–µ–≤—É—à–∫–∏, –∫–æ—Ç–æ—Ä–∞—è –≤–ª—é–±–ª—è–µ—Ç—Å—è –≤ 162-–ª–µ—Ç–Ω–µ–≥–æ –≤–∞–º–ø–∏—Ä–∞ –ø–æ –∏–º–µ–Ω–∏ –°—Ç–µ—Ñ–∞–Ω –°–∞–ª—å–≤–∞—Ç–æ—Ä–µ (–ü–æ–ª –£—ç—Å–ª–∏). –ò—Ö –æ—Ç–Ω–æ—à–µ–Ω–∏—è —Å—Ç–∞–Ω–æ–≤—è—Ç—Å—è –≤—Å–µ –±–æ–ª–µ–µ —Å–ª–æ–∂–Ω—ã–º–∏, –∫–æ–≥–¥–∞ –ø–æ—Ä–æ—á–Ω—ã–π —Å—Ç–∞—Ä—à–∏–π –±—Ä–∞—Ç –°—Ç–µ—Ñ–∞–Ω–∞ –î—ç–π–º–æ–Ω –°–∞–ª—å–≤–∞—Ç–æ—Ä–µ (–ò—ç–Ω –°–æ–º–µ—Ä—Ö–æ–ª–¥–µ—Ä) –≤–æ–∑–≤—Ä–∞—â–∞–µ—Ç—Å—è, —á—Ç–æ–±—ã –ø–æ—Å–µ—è—Ç—å —Ö–∞–æ—Å –≤ –≥–æ—Ä–æ–¥–µ –∏ –æ—Ç–æ–º—Å—Ç–∏—Ç—å —Å–≤–æ–µ–º—É –º–ª–∞–¥—à–µ–º—É –±—Ä–∞—Ç—É. –û–±–∞ –±—Ä–∞—Ç–∞ –≤–ª—é–±–ª—è—é—Ç—Å—è –≤ –ï–ª–µ–Ω—É –≤ –æ—Å–Ω–æ–≤–Ω–æ–º –∏–∑-–∑–∞ –µ—ë —Å—Ö–æ–¥—Å—Ç–≤–∞ —Å –∏—Ö –ø—Ä–æ—à–ª–æ–π –ª—é–±–æ–≤—å—é –ö—ç—Ç—Ä–∏–Ω –ü–∏—Ä—Å. –û–∫–∞–∑—ã–≤–∞–µ—Ç—Å—è, —á—Ç–æ –ï–ª–µ–Ω–∞ —è–≤–ª—è–µ—Ç—Å—è –¥–≤–æ–π–Ω–∏–∫–æ–º –ö—ç—Ç—Ä–∏–Ω, –∫–æ—Ç–æ—Ä–∞—è –≤ –∫–æ–Ω–µ—á–Ω–æ–º –∏—Ç–æ–≥–µ –≤–æ–∑–≤—Ä–∞—â–∞–µ—Ç—Å—è —Å —Å–µ—Ä—å—ë–∑–Ω—ã–º–∏ –ø–ª–∞–Ω–∞–º–∏ –ø–æ –æ—Ç–Ω–æ—à–µ–Ω–∏—é –∫ —Ç—Ä–∏–æ.','–ö–µ–≤–∏–Ω –£–∏–ª—å—è–º—Å–æ–Ω',1,'dnevniki-vampira.png');
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

-- Dump completed on 2016-03-10 16:45:28
