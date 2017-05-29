1、数据库导入，先建立 bbs数据库。
2、将bbs文件夹放在Apache服务器的www目录下。
3、（修改MySQL，登录名/密码）在bbs/Conf/Common.php文件夹中。
/* 数据库配置 */
'DB_TYPE'   => 'mysqli', // 数据库类型
'DB_HOST'   => '127.0.0.1', // 服务器地址
'DB_NAME'   => 'bbs', // 数据库名
'DB_USER'   => 'root', // 用户名
'DB_PWD'    => '123456',  // 密码
'DB_PORT'   => '3306', // 端口
'DB_PREFIX' => 'bbs_', // 数据库表前缀
4、后台用户名
admin	123456
5、论坛网页 http://localhost/opensns-3.3.0/index.php?s=/forum/index/index.html
   后台网页 http://localhost/opensns-3.3.0/admin.php