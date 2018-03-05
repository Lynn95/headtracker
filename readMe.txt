实验步骤

Arduino部分
Arduino结合第一次作业读取mpu6050陀螺仪沿xyz轴的加速度与角速度，并采用卡尔曼滤波来处理数据
来获得较稳定的数据；其次计算得出mpu6050的yaw pitch row值 并输出到com3口(windows下)
具体请参考作业中arduino部分的代码

Unity部分
首先需要搭建一个模拟游戏环境 具体参考以下博文
http://blog.csdn.net/yywan1314520/article/details/51404166

其次，为了实现headtracker的功能，我们需要模拟第一视角，那么在unity中游戏的视角呈现是与camera的位置有关
camera的位置可以手动设置为固定值，也可以通过脚本来实时控制。在本次实验中，我们通过脚本读取com3口的数据（yaw pitch row）
并设置为camera的值来控制camera的姿态，从而达到控制视角的目的。
camera有三个属性 positon rotation scale
positon的值用以改变camera的空间位置，可以用来模拟第三人称观测视角
但本次实验中我们的目的是模拟第一人称视角。所以用脚本来更改rotation的值
也就是camera在某个位置的角度。来模拟出上下左右看的时候视角的变化
具体脚本实现 请参考cameraMove.cs  位于unityScriptAndScene文件夹下



