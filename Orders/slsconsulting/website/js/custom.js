/*****************************************************************
 * **************************************************************
 * @MetCreative - Table of Contents
 * 1-) Document Ready State
 *    a- Scroll Speed and Styling
 *    b- Skill Circles
 *    c- LightBox
 *    d- DL Menu
 *    e- Icon Navigation Tabs
 *    f- Latest Posts Carousel
 *    h- Latest Tweets
 *    i- Twitter Ticker
 *    j- Gmaps JS for Google Maps
 *    h- Php Ajax Contact Form
 *    l- Blog List Iframe Sizing
 *    m- Portfolio List Iframe Sizing
 *    n- Contact Page Contact Form
 *    o- Responsive Navigation
 *    p- Full Screen Background Image
 *    r- Testimonials
 * 2-) Window Load State
 *    a- Index Slider
 *    b- Portfolio List Slider
 *    c- Blog Slider
 *    d- Recent Works Carousel
 *    d- Cacoon Slider
 * 2-) Functions
 *    a- Sticky Header
 *    b- Sticky Header Resizing
 * !Note: You can make search with one of the title above to find the block according to it
 * **************************************************************
 *****************************************************************/

$(document).ready(function(){

	/**
	 * Scroll Speed and Styling
	 * @usedPlugins jquery,nicescroll
	 * @usedAt      Every page that contains body tag with data-smooth-scrolling 1
	 */
	if($('body').attr('data-smooth-scrolling') == 1 && !jQuery.browser.mobile){
		$("html").niceScroll({
			scrollspeed: 60,
			mousescrollstep: 35,
			cursorwidth: 10,
			cursorborder: '1px solid #7E8A96',
			cursorcolor: '#18ADB6',
			cursorborderradius: 10,
			autohidemode: false,
			cursoropacitymin: 0.1,
			cursoropacitymax: 1
		});
	}

	/**
	 * Skill Circles
	 * @usedPlugins jquery, jquery.knob, jquery.easing
	 * @usedAt      services page
	 */
	var container = $('.dial');

	container.each(function() {
		var that = $(this),
			ao = Math.round(Math.random() * 360),
			w = container.data('width'),
			v = that.data('value');
		that.addClass('visible').knob({
			readOnly: true,
			bgColor: '#ebebeb',
			fgColor: '#18ADB5',
			thickness: 0.25,
			angleOffset: ao,
			width: w
		});
		$({value: 0}).animate({value: v}, {
			duration: 2000,
			easing:'easeOutQuad',
			step: function() {
				that.val(Math.ceil(this.value)).trigger('change');
			}
		})
	});

	/**
	 * LightBox
	 * @usedPlugins jquery, magnific-popup
	 * @usedAt      portfolio
	 */
	$('[rel*="lb"]').each(function(){
		$('[rel="'+$(this).attr('rel')+'"]').magnificPopup({
			type: 'image',
			gallery:{
				enabled: true
			}
		});
	});

	/**
	 * DL Menu
	 * @usedPlugins jquery, dlmenu
	 * @usedAt      shortcode
	 */
	$( '#dl-menu' ).dlmenu({
		animationClasses : { 'in' : 'dl-animate-in-3', 'out' : 'dl-animate-out-3' }
	});

	/**
	 * Icon Navigation Tabs
	 * @usedPlugins jquery
	 * @usedAt      Icon Navigation Tabs on Index Page
	 */
	$('.met_icon_tabs nav a').click(function(e){
		e.preventDefault();
		if(!$(this).hasClass('met_active_tab')){
			var tabContainer = $(this).parents('.met_icon_tabs');
			var href = $(this).attr('href');

			tabContainer.find('.met_active_tab').removeClass('met_active_tab');
			tabContainer.find('.met_open_tab').removeClass('met_open_tab');

			$(this).addClass('met_active_tab');
			$(this).addClass('met_active_tab');

			tabContainer.find(href).addClass('met_open_tab');
		}
	});

	/**
	 * Latest Posts Carousel
	 * @usedPlugins jquery,caroufredsel
	 * @usedAt      Latest Posts on Index Page
	 */
	$(".met_latest_posts").carouFredSel({
		responsive: true,
		pagination : {
			container		: $('.met_latest_posts_pages'),
			anchorBuilder	: function(nr) {
				return '<a href="#"><i class="icon-circle"></i></a>';
			}
		},
		circular: false,
		infinite: true,
		auto: {
			play : true,
			pauseDuration: 0,
			duration: 2000
		},
		scroll: {
			duration: 400,
			wipe: true,
			pauseOnHover: true
		},
		items: {
			visible: {
				min: 1,
				max: 1  },
			height: 'auto'
		},
		direction: 'up',
		onCreate: function(){
			$(window).trigger('resize');
		}
	});

	/**
	 * Latest Tweets
	 * @usedPlugins jquery,caroufredsel
	 * @usedAt      Latest Tweets on Index Page
	 */
	if($('.met_twitter_wrapper').length > 0){
		$.getJSON('twitter/get-tweets1.1.php?placement=onMiddle',
			function(feeds) {
				$('.met_twitter_wrapper').html('');
				for (var i=0; i<feeds.length; i++) {
					var status = feeds[i].text;
					$('.met_twitter_wrapper').append('<div class="met_twitter_item clearfix"><i class="icon-twitter"></i><p>'+status+'</p></div>');
				}
			}).done(function(){
				$(".met_twitter_wrapper").carouFredSel({
					responsive: true,
					circular: true,
					infinite: true,
					auto: {
						play : true,
						pauseDuration: 0,
						duration: 1000
					},
					scroll: {
						duration: 400,
						wipe: true,
						pauseOnHover: true
					},
					items: {
						visible: {
							min: 2,
							max: 3},
						height: 'auto'
					},
					direction: 'up',
					onCreate: function(){
						$(window).trigger('resize');
					}
				});
			});
	}

	/**
	 * Twitter Ticker
	 * @usedPlugins jquery,caroufredsel
	 * @usedAt      Twitter ticker above footer
	 */
	if($('.met_twitter_ticker').length > 0){
		$.getJSON('twitter/get-tweets1.1.php?placement=aboveFooter',
			function(feeds) {
				$('.met_twitter_ticker').html('');
				for (var i=0; i<feeds.length; i++) {
					var status = feeds[i].text;
					$('.met_twitter_ticker').append('<div class="met_color2">'+status+'</div>');
				}
			}).done(function(){
				$(".met_twitter_ticker").carouFredSel({
					responsive: true,
					prev: {
						button : function(){
							return $(this).parents('.met_news_ticker_wrapper').prev('.met_twitter_ticker_pager').children('a:first-child')
						}
					},
					next:{
						button : function(){
							return $(this).parents('.met_news_ticker_wrapper').prev('.met_twitter_ticker_pager').children('a:last-child')
						}
					},
					width: '100%',
					circular: false,
					infinite: true,
					auto: {
						play : true,
						pauseDuration: 0,
						duration: 2000
					},
					scroll: {
						items: 1,
						duration: 400,
						wipe: true
					},
					items: {
						visible: {
							min: 1,
							max: 1  },
						width: 795,
						height: 'auto'
					}
				});
			});
	}

	/**
	 * Gmaps JS for Google Maps
	 * @usedPlugins gmaps,gmaps sensor
	 * @usedAt      Contact page
	 */
	if($('#map').length > 0){
		var map = new GMaps({
			div: '#map',
			lat: -12.043333,
			lng: -77.028333
		});
		map.addMarker({
			lat: -12.043333,
			lng: -77.028333,
			title: 'MetCreative Office'
		});

		if($('.met_contact_map_box').length > 0){
			var mapBox = $('.met_contact_map_box').parent().html();
			$('.met_contact_map_box').remove();
			$('#map').append(mapBox);
		}
	}

	/**
	 * Php Ajax Contact Form
	 * @usedPlugins jquery
	 * @usedAt      Contact Page
	 */
	$('.met_contact_form').bind('submit', function(){
		var form    = $(this);
		var me      = $(this).children('input[type=submit]');

		me.attr('disabled','disabled');

		$.ajax({
			type: "POST",
			url: "mail.php",
			data: form.serialize(),
			success: function(returnedInfo){

				var message = $('.met_contact_thank_you');
				returnedInfo == 1 ? message.show() : message.html('Our Mail Servers Are Currently Down').show();
				setInterval(function(){message.fadeOut()},5000);
				me.removeAttr('disabled');

			}
		});
		return false;
	});

	/**
	 * Blog List Iframe Sizing
	 * @usedPlugins jquery
	 * @usedAt      Blog List Page
	 */
	var iframeVideos = $(".met_blog_video_iframe iframe"),
	iframeContainer = $(".met_blog_video_iframe");

	iframeVideos.each(function() {
		$(this).data('aspectRatio', this.height / this.width).removeAttr('height').removeAttr('width');
	});

	$(window).resize(function() {
		var newWidth = iframeContainer.width();

		iframeVideos.each(function() {
			var el = $(this);
			el.width(newWidth).height(newWidth * el.data('aspectRatio'));
		});
	}).resize();

	/**
	 * Portfolio List Iframe Sizing
	 * @usedPlugins jquery
	 * @usedAt      Portfolio List Page
	 */
	var iframeVideos = $(".met_portfolio_item_preview");

	if($(".met_portfolio_row .span6").length > 0){
		var iframeContainer = $(".met_portfolio_row .span6");
	}else{
		var iframeContainer = $(".met_portfolio_row .span4");
	}

	iframeVideos.each(function() {
		$(this).data('aspectRatio', this.height / this.width).removeAttr('height').removeAttr('width');
	});

	$(window).resize(function() {
		var newWidth = iframeContainer.width();

		iframeVideos.each(function() {
			var el = $(this);
			el.width(newWidth).height(newWidth * el.data('aspectRatio'));
		});
	}).resize();

	/**
	 * Contact Page Contact Form
	 * @usedPlugins jquery
	 * @usedAt      Contact Page
	 */
	if($(window).width() < 800 && $('.met_contact_map_box').length > 0){
		var box = $('.met_contact_map_box').html();
		var metContent = $('.met_contact_map_box').parents('.met_content');
		$('.met_contact_map_box').remove();
		metContent.append('<div class="row-fluid"><div class="span12"><div class="met_contact_map_box met_bgcolor3 met_color2" style="position: relative; top: 0; left: 0; right: auto; max-width: inherit;">'+box+'</div></div></div>');
	}

	/**
	 * Responsive Navigation
	 * @usedPlugins jquery
	 * @usedAt      Every page that contains responsive navigation select elements
	 */
	$('.met_responsive_nav').on('change',function(){
		window.location = $(this).val();
	});

	if($('.met_main_nav').data('fixed') == '1'){
		sticky_header();
		$(window).bind('scroll', sticky_header);
	}

	stickyHeaderSize();
	$(window).bind('resize', stickyHeaderSize);


	/**
	 * Full Screen Background Image
	 * @usedPlugins jquery
	 * @usedAt      Boxed Layout Body Background Image
	 */
	if(jQuery('#met_fullScreenImg').length > 0){
		var FullscreenrOptions = {  width: window.innerWidth, height: window.innerHeight, bgID: '#met_fullScreenImg' };
		jQuery.fn.fullscreenr(FullscreenrOptions);
	}

	/**
	 * Testimonials
	 * @usedPlugins jquery
	 * @usedAt      Testimonials
	 */
	var testimonialInterval;
	$('.met_testimonial_photos > div').hover(function(){
		var e = $(this);
		testimonialInterval = setInterval(function(){testimonialHoverOver(e)},100);
	},function(){
		var e = $(this);
		testimonialInterval = clearInterval(testimonialInterval);
		testimonialHoverOut(e);
	});
	function testimonialHoverOver(i){
		var id = i.index() + 1;
		i.parents('.met_testimonial_photos').next().children('div:nth-child('+id+')').slideDown();
	}
	function testimonialHoverOut(e){
		var id = e.index() + 1;
		e.parents('.met_testimonial_photos').next().children('div:nth-child('+id+')').slideUp();
	}

	/*$('.met_main_nav > ul > li').hover(function(){
		var theLi = $(this);
		if(theLi.children('ul').length > 0 && !theLi.hasClass('met_open_menu')){
			theLi.children('ul').fadeIn('fast');
			theLi.addClass('met_open_menu');
		}
	},function(){
		console.log('out triggered');
		var theLi = $(this);
		if(theLi.hasClass('met_open_menu')){
			theLi.children('ul').css('display', 'none');
			theLi.removeClass('met_open_menu');
		}
	});*/
	$('.met_main_nav > ul').superfish({
		delay: 250
	});

	logo_vertical_middle();
});

$(window).load(function(){

	/**
	 * Index Slider
	 * @usedPlugins jquery,caroufredsel
	 * @usedAt      Home Page
	 */
	$(".met_slider").carouFredSel({
		responsive: true,
		prev: {
			button : function(){
				return $(this).parents('.met_slider_wrap').find('.met_slider_nav_prev')
			}
		},
		next:{
			button : function(){
				return $(this).parents('.met_slider_wrap').find('.met_slider_nav_next')
			}
		},
		circular: false,
		infinite: true,
		auto: {
			play : true,
			pauseDuration: 0,
			duration: 2000
		},
		scroll: {
			items: 1,
			duration: 400,
			wipe: true,
			pauseOnHover: true,
			fx: 'crossfade'
		},
		items: {
			visible: {
				min: 1,
				max: 1
			},
			height: 'variable'
		},
		onCreate: function(){
			$(this).parents('.met_slider_wrap').find('.met_slider_overlay').fadeOut('fast',function(){
				$(this).remove();
			});
		}
	});

	/**
	 * Portfolio List Slider
	 * @usedPlugins jquery,caroufredsel
	 * @usedAt      Portfolio Listing Page
	 */
	$(".met_portfolio_item_slider").carouFredSel({
		responsive: true,
		prev: {
			button : function(){
				return $(this).parents('.met_portfolio_item_slider_wrap').find('.met_portfolio_item_slider_nav_prev')
			}
		},
		next:{
			button : function(){
				return $(this).parents('.met_portfolio_item_slider_wrap').find('.met_portfolio_item_slider_nav_next')
			}
		},
		circular: false,
		infinite: true,
		auto: {
			play : true,
			pauseDuration: 0,
			duration: 2000
		},
		scroll: {
			items: 1,
			duration: 400,
			wipe: true
		},
		items: {
			visible: {
				min: 1,
				max: 1
				},
			width: 691
		},
		width: 691
	});

	/**
	 * Blog Slider
	 * @usedPlugins jquery,caroufredsel
	 * @usedAt      Blog Detail
	 */
	$(".met_blog_slider").carouFredSel({
		responsive: true,
		prev: {
			button : function(){
				return $(this).parents('.met_blog_slider_wrap').find('.met_blog_slider_nav_prev')
			}
		},
		next:{
			button : function(){
				return $(this).parents('.met_blog_slider_wrap').find('.met_blog_slider_nav_next')
			}
		},
		circular: false,
		infinite: true,
		auto: {
			play : true,
			pauseDuration: 0,
			duration: 2000
		},
		scroll: {
			items: 1,
			duration: 400,
			wipe: true
		},
		items: {
			visible: {
				min: 1,
				max: 1
			},
			width: 870,
			height: 300
		},
		width: 870,
		height: 300
	});

	/**
	 * Recent Works Carousel
	 * @usedPlugins jquery,caroufredsel
	 * @usedAt      Recent Works on Index Page
	 */
	if($('body').width() < 800){
		var leftUp = 'left';
		var minItem = 1;
	}else{
		var leftUp = 'up';
		var minItem = 3;
	}
	$(".met_recent_works").carouFredSel({
		responsive: true,
		pagination : {
			container		: $('.met_recent_works_pages'),
			anchorBuilder	: function(nr) {
				return '<a href="#"><i class="icon-circle"></i></a>';
			}
		},
		circular: false,
		infinite: true,
		auto: {
			play : true,
			pauseDuration: 0,
			duration: 2000
		},
		scroll: {
			duration: 400,
			wipe: true,
			pauseOnHover: true
		},
		items: {
			visible: {
				min: minItem,
				max: 3},
			height: 'auto'
		},
		direction: leftUp,
		onCreate: function(){
			$(window).trigger('resize');
		}
	});

	/**
	 * Cacoon Slider
	 * @usedPlugins jquery,caroufredsel
	 * @usedAt      Recent Works on Index Page
	 */
	var $big = $('.met_thumbnail_slider_1_big .met_thumbnail_slider_1_images'),
		$small = $('.met_thumbnail_slider_1_small .met_thumbnail_slider_1_images');

	$big.carouFredSel({
		auto: {
			play : true,
			pauseDuration: 5000,
			duration: 300
		},
		direction: 'up',
		scroll: {
			items: 1,
			duration: 300,
			pauseOnHover: true,
			onBefore: function( data ) {

				var item = data.items.visible.first();
				var src = item.data( 'slider-format' ).split( '-' )[ 2 ];

				$('.met_active_title').removeClass('met_active_title');

				if(src == 'a' && !item.hasClass('met_first_slide')){
					$('.met_thumbnail_slider_1_next').trigger('click');
				}else if(item.hasClass('met_first_slide')){
					item.removeClass('met_first_slide');
				}
			},
			onAfter: function( data ){

				var item = data.items.visible.first();

				item.find('.met_thumbnail_slider_1_title,.met_thumbnail_slider_1_subtitle').addClass('met_active_title');

			}
		},
		items: {
			width: 'variable'
		},
		prev: {
			duration: 'auto'
		},
		next: {
			duration: 'auto'
		},
		onCreate: function( data ){
			var item = data.items.first();
			item.find('.met_thumbnail_slider_1_title,.met_thumbnail_slider_1_subtitle').addClass('met_active_title');
			$(this).parents('.met_thumbnail_slider_1_wrap').removeClass('met_thumbnail_slider_1_wrap_loading');
			$(this).parents('.met_thumbnail_slider_1_wrap').find('.met_thumbnail_slider_1_overlay').fadeOut('fast',function(){
				$(this).remove();
			});
		}
	});

	$small.carouFredSel({
		align: 'left',
		width: 'variable',
		auto: false,
		items:  4,
		scroll: {
			items: 'variable',
			duration: 300,
			onBefore: function( data ) {
				var item = data.items.visible.first();
				var src = item.data( 'slider-format' ).split( 'small-' )[ 1 ];
				$big.trigger( 'slideTo', [ '[data-slider-format="big-' + src + '"]', {
					fx: 'directscroll',
					duration: 300
				} ] );
			}
		}
	});

	$('.met_thumbnail_slider_1_small img').click(function() {
		if ( $big.triggerHandler( 'isScrolling' ) ) {
			return false;
		}
		var src = $(this).data( 'slider-format' ).split( 'small-' )[ 1 ];
		var isA = $(this).data( 'slider-format' ).split( '-' )[ 2 ];

		if(isA == 'a'){$('[data-slider-format="big-' + src + '"]').addClass('met_first_slide');}

		$big.trigger( 'slideTo', [ '[data-slider-format="big-' + src + '"]' ] );

		return false;
	});

	$('.met_thumbnail_slider_1_next').click(function() {

		if ( $small.triggerHandler( 'isScrolling' ) ) {
			return false;
		}
		var $visible = $small.triggerHandler( 'currentVisible' ),
			$next = $visible.last().next(),
			$new = $small.find( '[data-slider-format^="small-' + $next.data( 'slider-format' ).split( '-' )[ 1 ] + '-"]' );

		$small.trigger( 'configuration', [{
			items: {
				visible: $new.length
			}
		}, false] );


		$small.trigger( 'next', [ $visible.length ] );

		return false;
	});

});

/**
 * Sticky Header
 * @usedAt      global,window scroll, dom ready
 */
function sticky_header(){
	if($('body').width() > 800){
		if($('.met_main_nav').attr('data-fixed-width') == undefined) $('.met_main_nav').attr('data-fixed-width', $('.met_main_nav').width()+'px');
		if($('.met_main_nav').attr('data-fixed-left') == undefined) $('.met_main_nav').attr('data-fixed-left', $('.met_main_nav').offset().left+'px');

		if($(this).scrollTop() > 250 && $('.met_fixed_nav').length != 1){

			$('.met_main_nav').addClass('met_fixed_nav').css({
				'display' : 'none',
				'left' : $('.met_main_nav').attr('data-fixed-left'),
				'width' : $('.met_main_nav').attr('data-fixed-width')
			}).fadeIn('slow');

		}else if($(this).scrollTop() < 250 && $('.met_fixed_nav').length > 0){

			$('.met_fixed_nav').fadeOut('fast',function(){
				$('.met_fixed_nav').css({
					'left' : '0',
					'width' : 'asd'
				});
				$('.met_fixed_nav').removeClass('met_fixed_nav').fadeIn('fast');
			});

		}
	}
}


/**
 * Sticky Header Resizing
 * @usedAt      global,window scroll, dom ready, window resize
 */
function stickyHeaderSize(){
	$('.met_main_nav').attr('data-fixed-width', $('.met_content').width()+'px');
	$('.met_main_nav').attr('data-fixed-left', $('.met_content').offset().left+'px');

	if($('.met_fixed_nav').length > 0){
		$('.met_fixed_nav').css({
			'left' : $('.met_main_nav').attr('data-fixed-left'),
			'width' : $('.met_main_nav').attr('data-fixed-width')
		});
	}else{
		$('.met_main_nav').css({
			'left' : 0,
			'width' : $('.met_main_nav').attr('data-fixed-width')
		});
	}

}


/**
 * Logo Vertically Centering
 * @usedAt      global, dom ready, window resize
 */
function logo_vertical_middle(){
	var topSpace = Math.floor(Math.abs((150 - $('.met_logo img').attr('height')) / 2));

	$('.met_logo img').css({'margin-top': topSpace+'px'});

	$('.met_logo').removeClass('met_logo_loading');
}