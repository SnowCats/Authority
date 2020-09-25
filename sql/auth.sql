CREATE TABLE `base_organizations`  (
  `ID` char(36) NOT NULL COMMENT '主键',
  `ParentID` char(36) NULL COMMENT '上级组织ID',
  `Name` varchar(50) NULL COMMENT '组织名称',
  `Status` tinyint NULL COMMENT '状态',
  `Notes` text NULL COMMENT '备注',
  `CreatedOn` datetime NULL COMMENT '创建时间',
  `CreatedBy` char(36) NULL COMMENT '创建人',
  `ModifiedOn` datetime NULL COMMENT '修改时间',
  `ModifiedBy` char(36) NULL COMMENT '修改人',
  PRIMARY KEY (`ID`)
) COMMENT = '组织架构表';

CREATE TABLE `base_positions`  (
  `ID` char(36) NOT NULL COMMENT '主键',
  `OrgID` char(36) NULL COMMENT '组织ID',
  `Name` varchar(50) NULL COMMENT '职位名称',
  `Status` tinyint NULL COMMENT '状态',
  `Notes` text NULL COMMENT '备注',
  `CreatedOn` datetime NULL COMMENT '创建时间',
  `CreatedBy` varchar(36) NULL COMMENT '创建人',
  `ModifiedOn` datetime NULL COMMENT '修改时间',
  `ModifiedBy` varchar(36) NULL COMMENT '修改人',
  PRIMARY KEY (`ID`)
) COMMENT = '岗位表';

CREATE TABLE `base_roles`  (
  `ID` char(36) NOT NULL COMMENT '主键',
  `Name` varchar(50) NULL COMMENT '角色名称',
  `Status` tinyint NULL COMMENT '状态',
  `Notes` text NULL COMMENT '备注',
  `CreatedOn` datetime NULL COMMENT '创建时间',
  `CreatedBy` char(36) NULL COMMENT '创建人',
  `ModifiedOn` datetime NULL COMMENT '修改时间',
  `ModifiedBy` char(36) NULL COMMENT '修改人',
  PRIMARY KEY (`ID`)
) COMMENT = '角色表';

CREATE TABLE `base_user_roles`  (
  `ID` char(36) NOT NULL COMMENT '主键',
  `UserID` char(36) NULL COMMENT '用户ID',
  `RoleID` char(36) NULL COMMENT '角色ID',
  PRIMARY KEY (`ID`)
) COMMENT = '用户和角色关系表';

CREATE TABLE `base_users`  (
  `ID` char(36) NOT NULL COMMENT '主键',
  `Name` varchar(50) NULL COMMENT '姓名',
  `Gender` varchar(10) NULL COMMENT '性别',
  `UserName` varchar(50) NULL COMMENT '用户名',
  `Password` varchar(50) NULL COMMENT '密码',
  `Email` varchar(100) NULL COMMENT '邮箱',
  `Wechat` varchar(50) NULL COMMENT '微信',
  `Telephone` varchar(20) NULL COMMENT '手机号',
  `Phone` varchar(20) NULL COMMENT '座机',
  `PositionID` char(36) NULL COMMENT '岗位ID',
  `Address` varchar(255) NULL COMMENT '地址',
  `Status` tinyint NULL COMMENT '状态，0: 启用，1: 禁用',
  `Notes` text NULL COMMENT '备注',
  `CreatedOn` datetime NULL COMMENT '创建时间',
  `CreatedBy` char(36) NULL COMMENT '创建人',
  `ModifiedOn` datetime NULL COMMENT '修改时间',
  `ModifiedBy` char(36) NULL COMMENT '修改人',
  PRIMARY KEY (`ID`)
) COMMENT = '用户表';

CREATE TABLE `sys_apis`  (
  `ID` char(36) NOT NULL COMMENT '主键',
  `ModuleID` char(36) NULL COMMENT '模块名',
  `Name` varchar(50) NULL COMMENT '名称',
  `Route` text NULL COMMENT '路由',
  `Method` varchar(10) NULL COMMENT '接口方法',
  `Status` tinyint NULL COMMENT '状态',
  `Notes` text NULL COMMENT '备注',
  `CreatedOn` datetime NULL COMMENT '创建时间',
  `CreatedBy` char(36) NULL COMMENT '创建人',
  `ModifiedOn` datetime NULL COMMENT '修改时间',
  `ModifiedBy` char(36) NULL COMMENT '修改人',
  PRIMARY KEY (`ID`)
) COMMENT = '基础接口表';

CREATE TABLE `sys_module_permissions`  (
  `ID` char(36) NOT NULL COMMENT '主键',
  `ModuleID` char(36) NULL COMMENT '模块ID',
  `PermissionID` char(36) NULL COMMENT '权限ID',
  `Status` tinyint NULL COMMENT '状态',
  `CreatedOn` datetime NULL COMMENT '创建时间',
  `CreatedBy` char(36) NULL COMMENT '创建人',
  `ModifiedOn` datetime NULL COMMENT '修改时间',
  `ModifiedBy` char(36) NULL COMMENT '修改人',
  PRIMARY KEY (`ID`)
) COMMENT = '基础模块和权限关系表';

CREATE TABLE `sys_modules`  (
  `ID` char(36) NOT NULL COMMENT '主键',
  `ParentID` char(36) NULL COMMENT '上级菜单',
  `Name` varchar(50) NULL COMMENT '名称',
  `Icon` varchar(50) NULL COMMENT '字体图标',
  `Status` tinyint NULL COMMENT '状态',
  `Notes` text NULL COMMENT '备注',
  `CreatedOn` datetime NULL COMMENT '创建时间',
  `CreatedBy` char(36) NULL COMMENT '创建人',
  `ModifiedOn` datetime NULL COMMENT '修改时间',
  `ModifiedBy` char(36) NULL COMMENT '修改人',
  PRIMARY KEY (`ID`)
) COMMENT = '基础模块表';

CREATE TABLE `sys_permissions`  (
  `ID` char(36) NOT NULL,
  `Name` varchar(50) NULL,
  `Status` tinyint NULL,
  `Notes` varchar(4000) NULL,
  `CreatedOn` datetime NULL,
  `CreatedBy` char(36) NULL,
  `ModifiedOn` datetime NULL,
  `ModifiedBy` char(36) NULL,
  PRIMARY KEY (`ID`)
) COMMENT = '权限表';

CREATE TABLE `sys_settings`  (
  `ID` char(36) NOT NULL COMMENT '主键',
  `ParentKey` varchar(50) NULL COMMENT '上级Key',
  `CodeKey` varchar(50) NULL COMMENT '字典Key',
  `CodeValue` text NULL COMMENT '字典Value',
  `Status` tinyint NULL COMMENT '状态',
  `Notes` text NULL COMMENT '备注',
  `CreatedOn` datetime NULL COMMENT '创建时间',
  `CreatedBy` char(36) NULL COMMENT '创建人',
  `ModifiedOn` datetime NULL COMMENT '修改时间',
  `ModifiedBy` char(36) NULL COMMENT '修改人',
  PRIMARY KEY (`ID`)
) COMMENT = '字典表';

