// npm init
// npm i gulp gulp-sass node-sass gulp-beautify-code gulp-autoprefixer browser-sync
"use strict";

var gulp = require("gulp");
var sass = require("gulp-sass")(require("node-sass"));
var beautifyCode = require("gulp-beautify-code");
var autoprefixer = require("gulp-autoprefixer");
var browserSync = require("browser-sync").create();
// const purgecss = require('gulp-purgecss');

// gulp.task('purgecss', () => {
//   return gulp
//     .src('./src/css/**/*.css')
//     .pipe(
//       purgecss({
//         content: ['public/*.html', 'public/assets/js/*.js']
//       })
//     )
//     .pipe(beautifyCode())
//     .pipe(gulp.dest('./public/assets/css'))
// })

gulp.task("sass", function () {
  return (
    gulp
      .src("./Styles/styles.scss")
      .pipe(sass().on("error", sass.logError))
      .pipe(
        autoprefixer({
          cascade: false,
        })
      )
      .pipe(beautifyCode())
      .pipe(gulp.dest("./wwwroot/css"))
      // .pipe(gulp.dest("./public/assets/css"))
  );
});

module.exports.default = () => {
  browserSync.init({
    proxy: 'localhost:5000',
    notify: true,
    open: true
  });

  gulp.series("sass")();
  // gulp.watch("./src/css/**/*.css", gulp.series("purgecss"));
  gulp.watch("./Styles/**/*.scss", gulp.series("sass"));
  gulp.watch("./**/*.cshtml").on("change", browserSync.reload);
};
