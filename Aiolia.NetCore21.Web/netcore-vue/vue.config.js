﻿const webpack = require('webpack')

module.exports = {
    publicPath: '/',
    outputDir: '../wwwroot', // 打包的目录
    indexPath:"../Views/Home/Index.cshtml",
    lintOnSave: true, // 在保存时校验格式
    productionSourceMap: false, // 生产环境是否生成 SourceMap
    devServer: {
        open: true, // 启动服务后是否打开浏览器
        host: '0.0.0.0',
        port: 8080, // 服务端口
        https: false,
        hotOnly: false,
        proxy: null, // 设置代理
        before: app => { }
    },
    configureWebpack: {

        plugins: [

            new webpack.ProvidePlugin({

                $: "jquery",

                jQuery: "jquery",

                "windows.jQuery": "jquery"

            })

        ]

    }
}