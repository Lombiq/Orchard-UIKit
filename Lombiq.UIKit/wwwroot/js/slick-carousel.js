jQuery(($) => {
    document.querySelectorAll('.slickCarousel').forEach((element) => {
        const $carouselContainer = $(element);
        const $carousel = $carouselContainer.find('.slickCarousel__carousel');
        const $carouselArrows = $carouselContainer.find('.slickCarousel__arrows');

        $carousel.on('init', () => {
            // Carousel initializes elements with empty id attributes, which triggers HTML validation errors.
            // See: https://github.com/kenwheeler/slick/issues/4296
            $('.slickCarousel__item[id=""]').removeAttr('id');
        });

        let carouselSettings = {
            autoplay: true,
            mobileFirst: true,
            appendArrows: $carouselArrows,
        };

        const mergeSettingsJson = element.getAttribute('data-merge-settings');
        if (mergeSettingsJson && mergeSettingsJson[0] === '{') {
            const mergeSettings = JSON.parse(mergeSettingsJson);
            carouselSettings = $.extend(true, carouselSettings, mergeSettings);
        }

        // Apply the slide selector destructively, to avoid problems from the slide elements being on different
        // levels.
        if (carouselSettings.slide?.trim()) {
            const $items = $carousel.find('.slickCarousel__item');
            const $slides = $items.find(carouselSettings.slide);

            if ($slides.length) {
                $carousel.append($slides.addClass('slickCarousel__item'));
                $items.remove();
            }

            carouselSettings.slide = '';
        }

        $carousel.slick(carouselSettings);
    });
});
