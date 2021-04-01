const gulp = require('gulp');
const watch = require('gulp-watch');
const paths = require('./Gulp/paths');
const scssTargets = require('../../Utilities/Lombiq.Gulp.Extensions/Tasks/scss-targets');
const jsTargets = require('../../Utilities/Lombiq.Gulp.Extensions/Tasks/js-targets');


gulp.task('build:styles', scssTargets.build(paths.styles.base, paths.dist.css));

gulp.task('clean', scssTargets.clean(paths.dist.css));

gulp.task('build:js', () => jsTargets.compile(paths.scripts.base, paths.dist.js));

gulp.task('watch:styles', () => watch(paths.styles.all, { verbose: true }, gulp.parallel('build:styles')));

gulp.task('default', gulp.parallel('build:styles', 'build:js'));
