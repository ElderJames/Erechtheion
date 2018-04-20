# Erechtheion　　　　　　　　　　　　　　　　　　　　[中文](README.zh-cn.md)

## Migrate EF

Before our first release we can remove Migrations folder in DNIC.Erechtheion.EntityFrameworkCore, then re-migrate.

+ set DNIC.Erechtheion.EntityFrameworkCore as default project in Package Manager Console
+ run: add-migration Erechtheion -c ErechtheionDbContext

After release our project, we need to keep all migrations, if we changed entities, then

+ run: add-migration {what's changed} -c ErechtheionDbContext



