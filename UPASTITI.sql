-- phpMyAdmin SQL Dump
-- version 4.8.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 13, 2018 at 07:10 AM
-- Server version: 10.1.32-MariaDB
-- PHP Version: 5.6.36

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `upastiti`
--

-- --------------------------------------------------------

--
-- Table structure for table `contractor`
--

CREATE TABLE `contractor` (
  `contractorname` varchar(50) NOT NULL,
  `title` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `movement`
--

CREATE TABLE `movement` (
  `staffno` varchar(20) NOT NULL,
  `moveon` datetime NOT NULL,
  `shiftcode` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `plant`
--

CREATE TABLE `plant` (
  `plantname` varchar(50) NOT NULL,
  `title` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `samiti`
--

CREATE TABLE `samiti` (
  `samitiname` varchar(250) NOT NULL,
  `title` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `staff`
--

CREATE TABLE `staff` (
  `staffno` varchar(20) NOT NULL,
  `staffname` varchar(50) NOT NULL,
  `fathername` varchar(50) NOT NULL,
  `plantname` varchar(50) NOT NULL,
  `contractorname` varchar(20) NOT NULL,
  `gender` varchar(10) NOT NULL,
  `skilllevel` varchar(20) NOT NULL,
  `samitiname` varchar(250) NOT NULL,
  `status` varchar(10) DEFAULT NULL,
  `createdon` datetime DEFAULT NULL,
  `lastmodifiedon` datetime DEFAULT NULL,
  `finger1` varbinary(512) NOT NULL,
  `finger2` varbinary(512) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `contractor`
--
ALTER TABLE `contractor`
  ADD PRIMARY KEY (`contractorname`);

--
-- Indexes for table `movement`
--
ALTER TABLE `movement`
  ADD PRIMARY KEY (`staffno`);

--
-- Indexes for table `plant`
--
ALTER TABLE `plant`
  ADD PRIMARY KEY (`plantname`);

--
-- Indexes for table `samiti`
--
ALTER TABLE `samiti`
  ADD PRIMARY KEY (`samitiname`);

--
-- Indexes for table `staff`
--
ALTER TABLE `staff`
  ADD PRIMARY KEY (`staffno`),
  ADD KEY `samitiname` (`samitiname`),
  ADD KEY `plantname` (`plantname`),
  ADD KEY `contractorname` (`contractorname`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `movement`
--
ALTER TABLE `movement`
  ADD CONSTRAINT `movement_ibfk_1` FOREIGN KEY (`staffno`) REFERENCES `staff` (`staffno`);

--
-- Constraints for table `staff`
--
ALTER TABLE `staff`
  ADD CONSTRAINT `staff_ibfk_1` FOREIGN KEY (`samitiname`) REFERENCES `samiti` (`samitiname`),
  ADD CONSTRAINT `staff_ibfk_2` FOREIGN KEY (`plantname`) REFERENCES `plant` (`plantname`),
  ADD CONSTRAINT `staff_ibfk_3` FOREIGN KEY (`contractorname`) REFERENCES `contractor` (`contractorname`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
