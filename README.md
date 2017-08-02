# 高分统计遥感应用示范系统（一期）- 农业统计调查子系统

## 系统总体框架

    系统共包含数据管理，农作物识别和分类，抽样和面积估算，和碳储量核算四个模块。为便于
    多部门或人员开发，系统各模块拆分为单独可执行程序同步开发。最终整合集成为完整系统。

## 系统开发环境说明

    * 编译器：VS2010
    * GIS组件：ESRI ArcGis
    * 遥感处理组件：ENVI\IDL
    * 界面控件：Wpf、WinForm、DevExpress 14.1
    * 其他环境：根据各模块要求自行添加。

## 各模块开发说明

    * 为了方便修改和合作，所有界面无关的公开类和成员应按正规格式添加注释。

    * 尽量将业务逻辑和界面分离解耦。系统整体除各模块项目和系统主界面项目外，还包含名为 BLL的项目。所有公用的业务逻辑代码均应添加在此项目。

    * 各模块框架包含两个项目：项目名+UI 和 项目名+BLL。理论上，所有模块界面添加在UI 项目，所有逻辑代码添加在BLL项目。视各模块需求可自行添加项目，但原则上要保证UI和      业务分离。

