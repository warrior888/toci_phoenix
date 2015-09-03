var ContentLoader = {
    iterator: 1,

    sectionId: [
        '#home-section',
        '#about-section',
        '#services-section',
        '#contact-section',
        '#footer-section'
    ],

    sectionContent: [
        'home.html',
        'about.html',
        'services.html',
        'contact.html',
        'footer.html'
    ],

    ScrollHandler: function () {
        $(window).scroll(function () {

            var breakpoint = $(document).height() - $(window).height() - 10;
            var documentEnd = $(document).height() - $(window).height();

            // console.log('iterator 2: ', ContentLoader.iterator, ContentLoader.sectionContent[ContentLoader.iterator], $(document).height() - $(window).height());

            if (ContentLoader.iterator != ContentLoader.sectionContent.length - 1) {

                if (($(window).scrollTop() >= breakpoint) && ($(window).scrollTop() <= documentEnd )) {

                    $.get('server/content/' + ContentLoader.sectionContent[ContentLoader.iterator + 1], function (data) {

                        ++(ContentLoader.iterator);
                        // console.log(ContentLoader.iterator);
                        $(ContentLoader.sectionId[ContentLoader.iterator]).append(data);

                    });
                }
            }
        })
    },

    OnClickLoading: function (destSectionId) {

        if (this.iterator < this.sectionId.indexOf(destSectionId)) {

            for (this.iterator; this.iterator < this.sectionId.indexOf(destSectionId); this.iterator++) {

                var content = this.sectionContent[this.iterator + 1];
                var divId = this.sectionId[this.iterator + 1];


                    $.get('server/content/' + content, function (data) {
                        console.log('Wstawiam: ', content, ' do diva o id: ', divId, ContentLoader.iterator);
                        $(divId).append(data);
                    });

                }
            }
        console.log(this.iterator);
        }


    }




