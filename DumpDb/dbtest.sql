/*
 Navicat Premium Data Transfer

 Source Server         : localhost_3306
 Source Server Type    : MySQL
 Source Server Version : 80017
 Source Host           : localhost:3306
 Source Schema         : dbtest

 Target Server Type    : MySQL
 Target Server Version : 80017
 File Encoding         : 65001

 Date: 07/07/2022 17:33:17
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for __efmigrationshistory
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory`  (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------
INSERT INTO `__efmigrationshistory` VALUES ('20220701043259_ModelTool', '5.0.17');
INSERT INTO `__efmigrationshistory` VALUES ('20220705073409_addHistory', '5.0.17');
INSERT INTO `__efmigrationshistory` VALUES ('20220706062221_themFeild', '5.0.17');

-- ----------------------------
-- Table structure for input_tool_buy
-- ----------------------------
DROP TABLE IF EXISTS `input_tool_buy`;
CREATE TABLE `input_tool_buy`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `RequestBody` varchar(4000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `is_active` int(11) NOT NULL,
  `created_by` int(11) NULL DEFAULT NULL,
  `created_at` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 53 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of input_tool_buy
-- ----------------------------

-- ----------------------------
-- Table structure for roles
-- ----------------------------
DROP TABLE IF EXISTS `roles`;
CREATE TABLE `roles`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `is_active` tinyint(1) NULL DEFAULT NULL,
  `is_deleted` tinyint(1) NULL DEFAULT NULL,
  `created_at` datetime(6) NULL DEFAULT NULL,
  `created_by` int(11) NULL DEFAULT NULL,
  `modified_at` datetime(6) NULL DEFAULT NULL,
  `modified_by` int(11) NULL DEFAULT NULL,
  `deleted_at` datetime(6) NULL DEFAULT NULL,
  `deleted_by` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of roles
-- ----------------------------
INSERT INTO `roles` VALUES (1, 'Admin', 'Quản trị dự án', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `roles` VALUES (2, 'OperatingStaff', 'Nhân viên vận hành', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `roles` VALUES (3, 'MMStaff', 'Nhân viên MM', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `roles` VALUES (4, 'AccountantStaff', 'Nhân viên kế toán', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `roles` VALUES (5, 'Custorm', 'Khách hàng', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for transaction_history
-- ----------------------------
DROP TABLE IF EXISTS `transaction_history`;
CREATE TABLE `transaction_history`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_nft` int(11) NOT NULL,
  `class` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `rarity` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `address_wallet` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `TAU` double NOT NULL,
  `BNB` double NOT NULL,
  `USD` double NOT NULL,
  `Sell_TAU` double NOT NULL,
  `Buy_TAU` double NOT NULL,
  `Date_Sell` datetime(6) NULL DEFAULT NULL,
  `Date_Buy` datetime(6) NULL DEFAULT NULL,
  `Is_Selling` tinyint(1) NOT NULL,
  `is_check` int(11) NOT NULL,
  `is_active` int(11) NOT NULL,
  `token_id` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 21 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of transaction_history
-- ----------------------------

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `full_name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `user_name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `date_of_joining` datetime(6) NULL DEFAULT NULL,
  `role_id` int(11) NULL DEFAULT NULL,
  `is_active` int(11) NOT NULL,
  `is_deleted` int(11) NULL DEFAULT NULL,
  `email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `salt` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `created_by` int(11) NULL DEFAULT NULL,
  `created_at` datetime(6) NULL DEFAULT NULL,
  `modified_by` int(11) NULL DEFAULT NULL,
  `modified_at` datetime(6) NULL DEFAULT NULL,
  `deleted_at` datetime(6) NULL DEFAULT NULL,
  `deleted_by` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 16 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES (1, 'admin', 'admin', '2022-06-13 17:32:09.871123', 1, 1, 0, 'admin123123@gmail.com', 'MTIzNDU2QWFA', 'Yqevr76dPIP4mnimqd243Q==', NULL, '2022-06-13 17:32:09.871242', 1, '2022-06-16 14:09:54.093591', '2022-06-20 17:46:34.014704', 1);
INSERT INTO `users` VALUES (2, 'admin1', 'admin1', '2022-06-13 17:33:23.939230', 1, 1, 0, 'tet1111@gmail.com', 'MTIzNDU2enhj', 'nXL4s/OkLGBvhAcqExsZ+A==', 1, '2022-06-13 17:33:23.939277', 1, '2022-06-13 17:36:09.267794', '2022-06-20 17:46:38.217505', 1);
INSERT INTO `users` VALUES (4, 'admin2', 'admin2', '2022-06-15 11:58:36.425421', 1, 1, NULL, NULL, 'MTIzNDU2QWFA', 'IcjOGvs/LdlNhmAlSPeCXw==', 1, '2022-06-15 11:58:36.425480', NULL, NULL, '2022-06-16 14:52:35.624527', 1);
INSERT INTO `users` VALUES (6, 'admin123', 'admin123', '2022-06-15 17:19:17.114498', 1, 0, 0, NULL, 'MTIzNDU2QWFA', '22pXBfJ2mIRI9r5sKK6wGg==', 1, '2022-06-15 17:19:17.114553', NULL, NULL, '2022-06-16 18:01:34.659153', 1);
INSERT INTO `users` VALUES (7, 'user', 'user', '2022-06-15 17:24:24.309940', 3, 1, NULL, NULL, 'MTIzNDU2Nzg5', 'AnV1LNgQnjs/ZlY149ndhQ==', 1, '2022-06-15 17:24:24.309994', NULL, NULL, NULL, NULL);
INSERT INTO `users` VALUES (8, 'staff', 'staff', '2022-06-15 17:24:42.297599', 2, 1, NULL, NULL, 'MTIzNDU2', 'V6+C/kuEvzp8+0XCyQKLgA==', 1, '2022-06-15 17:24:42.297599', NULL, NULL, NULL, NULL);
INSERT INTO `users` VALUES (9, 'staff1', 'staff1', '2022-06-15 17:25:45.426647', 2, 1, NULL, NULL, 'MTIzNDU2QWFA', 'Tr7+xjpDsOb2FKiA05GRLw==', 1, '2022-06-15 17:25:45.426707', NULL, NULL, NULL, NULL);
INSERT INTO `users` VALUES (10, 'staff2', 'staff2', '2022-06-15 17:26:00.948216', 2, 1, NULL, NULL, 'MTIzNDU2QWFA', '/SZH7NnydhSxsaAKzCMztw==', 1, '2022-06-15 17:26:00.948217', NULL, NULL, NULL, NULL);
INSERT INTO `users` VALUES (11, 'user1', 'user1', '2022-06-15 17:26:18.899893', 3, 1, NULL, NULL, 'MTIzMTIz', 'yQJWd2BhK5yQcSsE6/50LA==', 1, '2022-06-15 17:26:18.899894', NULL, NULL, NULL, NULL);
INSERT INTO `users` VALUES (12, 'user2', 'user2', '2022-06-16 10:23:21.940860', 3, 1, NULL, NULL, 'MTIzNDU2QWFA', '8KrnPkSp0lGV7UInyrZe9g==', 1, '2022-06-16 10:23:21.940916', NULL, NULL, NULL, NULL);
INSERT INTO `users` VALUES (13, 'user3', 'user3', '2022-06-16 10:23:35.890931', 1, 1, NULL, NULL, 'MTIzNDU2QWFA', 'aVOoeCyavISFX7/fKuugQQ==', 1, '2022-06-16 10:23:35.890932', NULL, NULL, NULL, NULL);
INSERT INTO `users` VALUES (14, 'user4', 'user4', '2022-06-16 10:32:06.254401', 3, 1, NULL, NULL, 'MTIzNDU2QWFA', 'afRpMCfv9CAVg2iBTV1u8A==', 1, '2022-06-16 10:32:06.254463', NULL, NULL, NULL, NULL);
INSERT INTO `users` VALUES (15, 'user5', 'user5', '2022-06-16 10:32:16.693583', 3, 1, NULL, NULL, 'MTIzNDU2QWFA', 'Kfj4CuGFiNGc52QflDK9ww==', 1, '2022-06-16 10:32:16.693584', NULL, NULL, NULL, NULL);
INSERT INTO `users` VALUES (16, 'user6', 'user6', '2022-06-16 10:32:29.542785', 3, 1, NULL, NULL, 'MTIzNDU2QWFA', 'm+92BF2NJS8UYfJvr3isRA==', 1, '2022-06-16 10:32:29.542786', NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for users_roles
-- ----------------------------
DROP TABLE IF EXISTS `users_roles`;
CREATE TABLE `users_roles`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `users_id` int(11) NULL DEFAULT NULL,
  `roles_id` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `IX_USERS_ROLES_roles_id`(`roles_id`) USING BTREE,
  INDEX `IX_USERS_ROLES_users_id`(`users_id`) USING BTREE,
  CONSTRAINT `FK_USERS_ROLES_ROLES_roles_id` FOREIGN KEY (`roles_id`) REFERENCES `roles` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_USERS_ROLES_USERS_users_id` FOREIGN KEY (`users_id`) REFERENCES `users` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 16 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of users_roles
-- ----------------------------
INSERT INTO `users_roles` VALUES (1, 1, 1);
INSERT INTO `users_roles` VALUES (2, 2, 1);
INSERT INTO `users_roles` VALUES (4, 4, 1);
INSERT INTO `users_roles` VALUES (6, 6, 1);
INSERT INTO `users_roles` VALUES (7, 7, 3);
INSERT INTO `users_roles` VALUES (8, 8, 2);
INSERT INTO `users_roles` VALUES (9, 9, 2);
INSERT INTO `users_roles` VALUES (10, 10, 2);
INSERT INTO `users_roles` VALUES (11, 11, 3);
INSERT INTO `users_roles` VALUES (12, 12, 3);
INSERT INTO `users_roles` VALUES (13, 13, 1);
INSERT INTO `users_roles` VALUES (14, 14, 3);
INSERT INTO `users_roles` VALUES (15, 15, 3);
INSERT INTO `users_roles` VALUES (16, 16, 3);

-- ----------------------------
-- Table structure for wallet_management
-- ----------------------------
DROP TABLE IF EXISTS `wallet_management`;
CREATE TABLE `wallet_management`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `private _key` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `address_wallet` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `TAU` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `BNB` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `is_check` int(11) NOT NULL,
  `is_active` int(11) NOT NULL,
  `is_deleted` int(11) NULL DEFAULT NULL,
  `created_by` int(11) NULL DEFAULT NULL,
  `created_at` datetime(6) NULL DEFAULT NULL,
  `modified_by` int(11) NULL DEFAULT NULL,
  `modified_at` datetime(6) NULL DEFAULT NULL,
  `deleted_at` datetime(6) NULL DEFAULT NULL,
  `deleted_by` int(11) NULL DEFAULT NULL,
  `users_id` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `IX_WALLET_MANAGEMENT_users_id`(`users_id`) USING BTREE,
  CONSTRAINT `FK_WALLET_MANAGEMENT_USERS_users_id` FOREIGN KEY (`users_id`) REFERENCES `users` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of wallet_management
-- ----------------------------
INSERT INTO `wallet_management` VALUES (1, 'fa6efc4e56c2c99d8d515810bc8ac62bf063d2c45dc4f3803dc703b2ded7df3f', '0xC15dc1080AfbC0e0498C73880aDbF78E2e573d4f', '87736.18', '0.47428018', 0, 1, NULL, 1, '2022-07-04 10:12:07.354460', NULL, NULL, NULL, NULL, 1);
INSERT INTO `wallet_management` VALUES (2, '77bbef0b05a8029584d83296d42cab0170a14d46bc916ec8184303a5cd44973a', '0xca954B569e7f193d853Ccb571ff2E1Fd957694d5', '1013140.54', '0.344085792', 1, 1, NULL, 1, '2022-07-04 10:12:18.569862', NULL, NULL, NULL, NULL, 1);

SET FOREIGN_KEY_CHECKS = 1;
