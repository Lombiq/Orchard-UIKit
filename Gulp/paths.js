const assetsBasePath = './Assets/';
const stylesBasePath = assetsBasePath + 'Styles/';
const scriptsBasePath = assetsBasePath + 'Scripts/';
const distBasePath = './wwwroot/';

module.exports = {
    styles: {
        base: stylesBasePath,
        all: stylesBasePath + '**/*.scss',
    },
    scripts: {
        base: scriptsBasePath,
        all: scriptsBasePath + '**/*.js',
    },
    dist: {
        base: distBasePath,
        images: distBasePath + 'images/',
        css: distBasePath + 'css/',
        fonts: distBasePath + 'fonts/',
        js: distBasePath + 'js/',
    },
};
