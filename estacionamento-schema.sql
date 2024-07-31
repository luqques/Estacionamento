CREATE DATABASE  IF NOT EXISTS `estacionamento` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `estacionamento`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: estacionamento
-- ------------------------------------------------------
-- Server version	8.0.37

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
-- Table structure for table `registroestacionamento`
--

DROP TABLE IF EXISTS `registroestacionamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `registroestacionamento` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `VeiculoId` int NOT NULL,
  `TabelaDePrecosId` int DEFAULT NULL,
  `DataHoraEntrada` datetime NOT NULL,
  `DataHoraSaida` datetime DEFAULT NULL,
  `ValorPagar` decimal(10,2) DEFAULT NULL,
  `Duracao` time DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RegistroEstacionamento_TabelaDePrecosId` (`TabelaDePrecosId`),
  KEY `IX_RegistroEstacionamento_VeiculoId` (`VeiculoId`),
  CONSTRAINT `FK_RegistroEstacionamento_Veiculo_VeiculoId` FOREIGN KEY (`VeiculoId`) REFERENCES `veiculo` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registroestacionamento`
--

LOCK TABLES `registroestacionamento` WRITE;
/*!40000 ALTER TABLE `registroestacionamento` DISABLE KEYS */;
INSERT INTO `registroestacionamento` VALUES (18,31,6,'2024-07-29 17:51:26','2024-07-29 17:51:31',1.00,'00:00:05'),(19,32,6,'2024-07-29 17:52:03','2024-07-29 22:05:27',9.00,'04:13:24'),(20,33,6,'2024-07-30 01:12:23','2024-07-30 01:32:28',1.00,'00:20:05'),(21,34,6,'2024-07-30 01:23:11','2024-07-30 19:52:23',37.00,'18:29:12'),(22,35,6,'2024-07-30 03:00:18','2024-07-30 19:57:35',33.00,'16:57:17'),(23,36,6,'2024-07-30 19:57:06','2024-07-30 19:57:19',1.00,'00:00:13');
/*!40000 ALTER TABLE `registroestacionamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tabeladeprecos`
--

DROP TABLE IF EXISTS `tabeladeprecos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tabeladeprecos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `PrecoHora` decimal(10,2) NOT NULL,
  `DataHoraCadastro` datetime NOT NULL,
  `PrecoHoraAdicional` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tabeladeprecos`
--

LOCK TABLES `tabeladeprecos` WRITE;
/*!40000 ALTER TABLE `tabeladeprecos` DISABLE KEYS */;
INSERT INTO `tabeladeprecos` VALUES (6,2.00,'2024-07-29 17:51:21',1.00);
/*!40000 ALTER TABLE `tabeladeprecos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `veiculo`
--

DROP TABLE IF EXISTS `veiculo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `veiculo` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Placa` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `NomeProprietario` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Modelo` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `veiculo`
--

LOCK TABLES `veiculo` WRITE;
/*!40000 ALTER TABLE `veiculo` DISABLE KEYS */;
INSERT INTO `veiculo` VALUES (31,'PLACA1','Lucas','FIAT'),(32,'PLACA2','Helena','HB20'),(33,'PLACA3','Lucas','HB20'),(34,'PLACA7','Lucas da Cunha','Fiat Uno'),(35,'QWRE123','lucas','gol'),(36,'PLACA123','Lucas da Cunha','HB20');
/*!40000 ALTER TABLE `veiculo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-07-30 20:14:40
