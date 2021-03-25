const path = require('path');
const resolve = dir => path.join(__dirname, dir);
//const IS_PROD = ["production", "prod"].includes(process.env.NODE_ENV);

module.exports = {
  transpileDependencies: [
    'vuetify'
  ],
  chainWebpack: config => {
    // 添加别名
    config.resolve.alias
      .set("@", resolve("src"))
      .set("@assets", resolve("src/assets"))
      .set("@components", resolve("src/components"))
      .set("@plugins", resolve("src/plugins"))
      .set("@views", resolve("src/views"))
      .set("@router", resolve("src/router"))
      .set("@store", resolve("src/store"))
      .set("@layouts", resolve("src/layouts"))
      .set("@static", resolve("src/static"));
  },
  css: {
    requireModuleExtension: true,
    sourceMap: true,
    loaderOptions: {
      // pass options to sass-loader
      // @/ is an alias to src/
      // so this assumes you have a file named `src/variables.sass`
      // Note: this option is named as "prependData" in sass-loader v8
      sass: {
        //additionalData?: `@import "@assets/variables/app.scss"`,
      },
      // by default the `sass` option will apply to both syntaxes
      // because `scss` syntax is also processed by sass-loader underlyingly
      // but when configuring the `prependData` option
      // `scss` syntax requires an semicolon at the end of a statement, while `sass` syntax requires none
      // in that case, we can target the `scss` syntax separately using the `scss` option
      scss: {
        //additionalData: `@import "@assets/variables/app.scss";`
        // additionalData(content, loaderContext) {
        //   const { resourcePath, rootContext } = loaderContext
        //   const relativePath = path.relative(rootContext, resourcePath)
        //   if (
        //     relativePath.replace(/\\/g, '/') !== 'src/assets/variables/app.scss'
        //   ) {
        //     return '@import "@assets/variables/app.scss";' + content
        //   }
        //   return content
        // },
      },
    }
  }
}
