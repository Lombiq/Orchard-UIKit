const gulp = require('gulp');
const watch = require('gulp-watch');
const paths = require('./Gulp/paths');
const scssTargets = require('../../Utilities/Lombiq.Gulp.Extensions/Tasks/scss-targets');
const jsTargets = require('../../Utilities/Lombiq.Gulp.Extensions/Tasks/js-targets');

gulp.task('build:styles', scssTargets.build(paths.styles.base, paths.dist.css));
gulp.task('build:scripts', () => jsTargets.compile(paths.scripts.base, paths.dist.js));

gulp.task('clean', gulp.series(scssTargets.clean(paths.dist.css), jsTargets.clean(paths.dist.js)));

gulp.task('watch:styles', () => watch(paths.styles.all, { verbose: true }, gulp.series('build:styles')));
gulp.task('watch:scripts', () => watch(paths.scripts.all, { verbose: true }, gulp.series('build:scripts')));

gulp.task('watch', () => {
    watch(paths.styles.all, { verbose: true }, gulp.series('build:styles'));
    watch(paths.scripts.all, { verbose: true }, gulp.series('build:scripts'));
});

gulp.task('default', gulp.parallel('build:styles', 'build:scripts'));
