# MuseDash-QuickSwitchCombination

玩家可以使用快捷键切换角色和精灵组合

## 如何安装

安装[MelonLoader](https://github.com/HerpDerpinstine/MelonLoader/releases/latest/download/MelonLoader.Installer.exe)，然后把QuickSwitchCombination.dll（你可以在[这里](https://github.com/lxymahatma/MuseDash-QuickSwitchCombination/releases)下载）放到mods文件夹底下

## 如何使用

当你把dll文件放到mods文件夹底下并且启动游戏的时候，此mod会自动在MuseDash安装目录底下的UserData文件夹里生成一个QuickSwitchCombination.cfg的文件

* 默认设置的重载键为F10
* 默认设置的菜单栏键为F11（还在开发中）
* 第一个参数为切换使用的快捷键
* 第二个参数为切换的人物
* 第三个参数为切换的精灵

### 例子

如果你想要用F12当作快捷键，快速切换小恶魔和莉莉丝，你应该这么写：

[[datas]]

Key = "F12"

Character = "小恶魔"

Elfin = "莉莉丝"

（文件里有带#号行的为注释可以不用管）

## 注意一下几点

* 文件里的参数的语言必须和当前游戏设置语言对应
* 你可以有多个设置，只要在设置完一行以同样格式写到下一行即可

## 另

此mod可以与thegamemaster1234的FavGirl一起使用（即可以使用梦游皮小恶魔）

# 感谢

MuseDash-QuickSwitchCombination使用了这个项目的一些代码：
https://github.com/BustR75/MuseDashAnySkill

非常感谢BustR75的源代码以及指导如何优化代码！

## 一些想说的

因为本人是新手，所以不要在意用了很复杂的方法才做出来的mod啦