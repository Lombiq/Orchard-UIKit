jQuery(function ($) {
    document.querySelectorAll('.slickCarousel').forEach(function (element) {
        const $carouselContainer = $(element);
        const $carousel = $carouselContainer.find(".slickCarousel__carousel");
        const $carouselArrows = $carouselContainer.find(".slickCarousel__arrows");

        $carousel.on("init", () => {
            // Carousel initializes elements with empty id attributes, which triggers HTML validation errors.
            // See: https://github.com/kenwheeler/slick/issues/4296
            $carousel.find("[id]").filter((_, element) => element.id === "").removeAttr("id");
        });

        let carouselSettings = {
            autoplay: true,
            mobileFirst: true,
            appendArrows: $carouselArrows
        };

        const mergeSettingsJson = element.getAttribute('data-merge-settings');
        if (mergeSettingsJson && mergeSettingsJson[0] === '{') {
            const mergeSettings = JSON.parse(mergeSettingsJson);
            carouselSettings = $.extend(true, carouselSettings, mergeSettings);
        }

        $carousel.slick(carouselSettings);
    });
});
