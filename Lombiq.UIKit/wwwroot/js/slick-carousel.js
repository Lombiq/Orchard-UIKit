jQuery(($) => {
    document.querySelectorAll('.slickCarousel').forEach((containerElement) => {
        const carousel = containerElement.querySelector('.slickCarousel__carousel');

        const findItems = () => Array.from(carousel.querySelectorAll('.slickCarousel__item'));

        let carouselSettings = {
            autoplay: true,
            mobileFirst: true,
            appendArrows: '.slickCarousel__arrows',
        };

        const mergeSettingsJson = containerElement.getAttribute('data-merge-settings');
        if (mergeSettingsJson && mergeSettingsJson[0] === '{') {
            const mergeSettings = JSON.parse(mergeSettingsJson);
            carouselSettings = $.extend(true, carouselSettings, mergeSettings);
        }

        // Apply the slide selector destructively, to avoid problems from the slide elements being on different levels.
        if (carouselSettings.slide?.trim()) {
            const originalItems = findItems();
            const $slides = $(carouselSettings.slide, originalItems)
                .addClass('slickCarousel__item')
                .appendTo(carousel);

            if ($slides.length) {
                originalItems.forEach((item) => item.remove());
            }

            carouselSettings.slide = '';
        }

        $(carousel).slick(carouselSettings);
    });
});
