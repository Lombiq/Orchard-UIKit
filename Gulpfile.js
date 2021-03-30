const gulp = require('gulp');
const jsTargets = require('../../Utilities/Lombiq.Gulp.Extensions/Tasks/js-targets');

gulp.task('default', () => jsTargets.compile('./Assets/Scripts/', './wwwroot/lombiq-uikitscripts'));
