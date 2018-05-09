# Erechtheion　　　　　　　　　　　　　　　　　　　[English](README.md)

#### 概述

本项目是 dotnet-china 的论坛项目

+ .NET CORE SDK >= 2.0
+ Visual Studio 2017 社区版或 JetBrains Rider 2017.3

#### 设计

+ 使用 EF 做 CodeFirst 工具, 仅用于数据库创建和迁移: DNIC.Erechtheion.Migrator

#### 创建数据库

##### 开发者

+ 设置 DNIC.Erechtheion 为启动项目
+ 在 Package Mananger Console中运行 update-database

##### 生产环境

+ 提供WEB安装界面, 执行完整的SQL脚本