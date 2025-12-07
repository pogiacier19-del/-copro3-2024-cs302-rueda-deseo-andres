-- MySQL dump 10.13  Distrib 8.0.44, for Win64 (x86_64)
--
-- Host: localhost    Database: ditr
-- ------------------------------------------------------
-- Server version	8.0.44

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `characterdata`
--

DROP TABLE IF EXISTS `characterdata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `characterdata` (
  `Character_Name` varchar(20) DEFAULT NULL,
  `Gender` varchar(15) DEFAULT NULL,
  `BodyType` varchar(20) DEFAULT NULL,
  `SkinColor` varchar(20) DEFAULT NULL,
  `HairColor` varchar(20) DEFAULT NULL,
  `EyeColor` varchar(20) DEFAULT NULL,
  `EyebrowThickness` varchar(20) DEFAULT NULL,
  `BaseballBatTexture` varchar(20) DEFAULT NULL,
  `BaseballBatDesign` varchar(20) DEFAULT NULL,
  `Shoes` varchar(20) DEFAULT NULL,
  `ShirtDesgin` varchar(20) DEFAULT NULL,
  `PantsDesign` varchar(20) DEFAULT NULL,
  `Accessories` varchar(20) DEFAULT NULL,
  `Cap` varchar(20) DEFAULT NULL,
  `Socks` varchar(20) DEFAULT NULL,
  `PreferredPosition` varchar(20) DEFAULT NULL,
  `TeamMascot` varchar(20) DEFAULT NULL,
  `Perks` varchar(20) DEFAULT NULL,
  `IsAtlethic` tinyint(1) DEFAULT NULL,
  `IsAgile` tinyint(1) DEFAULT NULL,
  `IsTenacious` tinyint(1) DEFAULT NULL,
  `IsSharp` tinyint(1) DEFAULT NULL,
  `Strength` tinyint DEFAULT NULL,
  `Speed` tinyint DEFAULT NULL,
  `Stamina` tinyint DEFAULT NULL,
  `Accuracy` tinyint DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characterdata`
--

LOCK TABLES `characterdata` WRITE;
/*!40000 ALTER TABLE `characterdata` DISABLE KEYS */;
INSERT INTO `characterdata` VALUES ('fluff','Male','Slim','Fair','Black','Black','Thick','Metallic','Punk','Jollibee boots','Novice shirt','Novice pants','Glasses','Novice cap','Programming socks','Pitcher','Jollibee','Berserker',1,1,1,0,19,6,6,3),('Raign','Female','Athletic','Neon','Blue','Blue','Pointed eyebrows','Carbon','Blaze','Black shoes','Vintage','Animal print pants','Piercings','Knight helmet','Camouflage socks','Right fielder','Spiderman','Paranoia',0,0,1,1,13,6,9,6),('Acier','Male','Stocky','Neon','Blue','Blue','Pointed eyebrows','Alloy','Reaver','Terraspark Boots','Animal print','Vintage pants','Masks','Dog ears','Camouflage socks','Right fielder','Doraemon','Drunk',1,1,0,0,14,11,3,6),('fluffo','Male','Slim','Fair','Black','Black','Thick','Metallic','Punk','Jollibee boots','Novice shirt','Novice pants','Glasses','Novice cap','Programming socks','Pitcher','Jollibee','Berserker',1,1,1,1,16,6,6,6),('epalNard','Female','Lean','Medium','Brown','Brown','Thin','Wood','Apocalyptic','Sneakers','Leather jacket','Biker pants','Earrings','Reversed Cap','Unicorn socks','Umpire','Ronald McDonald','Charge up speed!',1,1,1,0,14,9,8,3),('usercs','Male','Muscular','Deep','Green','Green','No eyebrows','Plastic','Glitch pop','Black shoes','Vintage','Vintage pants','Headbands','Cat ears','Binary socks','Infielder','Wendy','Hyperfixation',1,1,1,1,11,11,6,6);
/*!40000 ALTER TABLE `characterdata` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-12-06 23:49:39
