-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 24, 2024 at 02:06 AM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `e_voting`
--

-- --------------------------------------------------------

--
-- Table structure for table `admins`
--

CREATE TABLE `admins` (
  `adminId` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admins`
--

INSERT INTO `admins` (`adminId`, `password`) VALUES
('admin', 'pass_admin');

-- --------------------------------------------------------

--
-- Table structure for table `aspirants`
--

CREATE TABLE `aspirants` (
  `id` int(11) NOT NULL,
  `candidateId` varchar(45) NOT NULL,
  `fullName` varchar(45) NOT NULL,
  `programme` varchar(45) NOT NULL,
  `titleId` int(11) NOT NULL,
  `imageUri` longblob NOT NULL,
  `createdAt` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `studentId` varchar(45) NOT NULL,
  `password` mediumtext NOT NULL,
  `fullName` varchar(45) NOT NULL,
  `programme` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `titles`
--

CREATE TABLE `titles` (
  `titleId` int(11) NOT NULL,
  `name` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `titles`
--

INSERT INTO `titles` (`titleId`, `name`) VALUES
(3, 'Organizer'),
(1, 'President'),
(4, 'Secretary'),
(2, 'Vice President');

-- --------------------------------------------------------

--
-- Table structure for table `votings`
--

CREATE TABLE `votings` (
  `studentId` varchar(45) NOT NULL,
  `titleId` int(11) NOT NULL,
  `aspirantId` int(11) NOT NULL,
  `createdAt` date NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admins`
--
ALTER TABLE `admins`
  ADD PRIMARY KEY (`adminId`);

--
-- Indexes for table `aspirants`
--
ALTER TABLE `aspirants`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `candidateId_UNIQUE` (`candidateId`),
  ADD KEY `fk_aspirant_title_idx` (`titleId`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`studentId`),
  ADD UNIQUE KEY `studentscol_UNIQUE` (`studentId`);

--
-- Indexes for table `titles`
--
ALTER TABLE `titles`
  ADD PRIMARY KEY (`titleId`),
  ADD UNIQUE KEY `name_UNIQUE` (`name`);

--
-- Indexes for table `votings`
--
ALTER TABLE `votings`
  ADD PRIMARY KEY (`studentId`,`titleId`,`createdAt`),
  ADD KEY `idx_titleId` (`titleId`),
  ADD KEY `idx_aspirantId` (`aspirantId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aspirants`
--
ALTER TABLE `aspirants`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `titles`
--
ALTER TABLE `titles`
  MODIFY `titleId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `aspirants`
--
ALTER TABLE `aspirants`
  ADD CONSTRAINT `fk_aspirant_title` FOREIGN KEY (`titleId`) REFERENCES `titles` (`titleId`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Constraints for table `votings`
--
ALTER TABLE `votings`
  ADD CONSTRAINT `fk_votings_aspirant` FOREIGN KEY (`aspirantId`) REFERENCES `aspirants` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_votings_student` FOREIGN KEY (`studentId`) REFERENCES `students` (`studentId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_votings_title` FOREIGN KEY (`titleId`) REFERENCES `titles` (`titleId`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
