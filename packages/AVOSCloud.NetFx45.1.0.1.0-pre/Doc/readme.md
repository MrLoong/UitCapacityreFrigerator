# LeanCloud SDK 安装事项

## Windows Desktop
Windows 桌面版依赖一个 sqlite3.dll 的 c++ 的组件做本地聊天消息的缓存，所以在安装完毕之后需要把 content/sqlite3.dll 里面的内容拷贝到项目里面，
并且设置它的
* Build Action ：Content 
* Copy to Output Directory ： Copy if newer

如此做才能确保 SDK 运行时不会出错，否则在初始化的时候就会遇到异常。