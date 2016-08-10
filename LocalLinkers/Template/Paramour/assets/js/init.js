/* ==================================================
//  ____  _     _   _            _   _          _____ _                              
// |  _ \(_)___| |_(_)_ __   ___| |_(_)_   ____|_   _| |__   ___ _ __ ___   ___  ___ 
// | | | | / __| __| | '_ \ / __| __| \ \ / / _ \| | | '_ \ / _ \ '_ ` _ \ / _ \/ __|
// | |_| | \__ \ |_| | | | | (__| |_| |\ V /  __/| | | | | |  __/ | | | | |  __/\__ \
// |____/|_|___/\__|_|_| |_|\___|\__|_| \_/ \___||_| |_| |_|\___|_| |_| |_|\___||___/
//
/* ==================================================

/* ==================================================
   THEME FUNCTIONS
================================================== */
$(document).ready(function(){	
	'use strict';

	var mobileMenuClone = $('.sticky-nav #menu').clone().attr('id', 'navigation-mobile');
	mobileMenuClone.insertAfter('.sticky-nav #menu');

	var mobileMenuClone2 = $('.home-nav #menu').clone().attr('id', 'navigation-mobile');
	mobileMenuClone2.insertAfter('.home-nav #menu');

	var windowWidth = $(window).width();
	
	if( windowWidth <= 979 ) {
		if( $('.mobile-nav').length > 0 ) {			
			$('#navigation-mobile #menu-nav').attr('id', 'menu-nav-mobile');
		}
	} else {
		$('#navigation-mobile').css('display', 'none');
		if ($('.mobile-nav').hasClass('open')) {
			$('.mobile-nav').removeClass('open');	
		}
	}
});

$(document).ready(function(){
	'use strict';	
	$('.home-nav .mobile-nav').on('click', function(e){
		$(this).toggleClass('open');
		
		if ($('.home-nav .mobile-nav').hasClass('open')) {
			$('.home-nav #navigation-mobile').slideDown(500, 'easeOutExpo');
		} else {
			$('.home-nav #navigation-mobile').slideUp(500, 'easeOutExpo');
		}
		e.preventDefault();
	});
	
	$('.home-nav #menu-nav-mobile a:not(.dropdown-toggle)').on('click', function(){
		$('.home-nav .mobile-nav').removeClass('open');
		$('.home-nav #navigation-mobile').slideUp(350, 'easeOutExpo');
	});

	$('.sticky-nav .mobile-nav').on('click', function(e){
		$(this).toggleClass('open');
		
		if ($('.sticky-nav .mobile-nav').hasClass('open')) {
			$('.sticky-nav #navigation-mobile').slideDown(500, 'easeOutExpo');
		} else {
			$('.sticky-nav #navigation-mobile').slideUp(500, 'easeOutExpo');
		}
		e.preventDefault();
	});
	
	$('.sticky-nav #menu-nav-mobile a:not(.dropdown-toggle)').on('click', function(){
		$('.sticky-nav .mobile-nav').removeClass('open');
		$('.sticky-nav #navigation-mobile').slideUp(350, 'easeOutExpo');
	});

	/* Slide Sync to Carousel */
	jQuery('#home-slider #prevslide').click(function(x) { x.preventDefault(); jQuery('#home-slider').data('backstretch').prev(); });
	jQuery('#home-slider #nextslide').click(function(x) { x.preventDefault(); jQuery('#home-slider').data('backstretch').next(); });

    $('.flip').on({
	    mouseenter: function(){
	        $(this).find('.card').addClass('flipped');
	    },
	    mouseleave: function(){
	        $(this).find('.card').removeClass('flipped');
	    }
	});
});


/* ==================================================
   Navigation Fix
================================================== */
$(document).ready(function(){	
	'use strict';
	$('.sticky-nav').waypoint('sticky');
});


/* ==================================================
   Filter Works
================================================== */
$(document).ready(function(){	
	'use strict';
	if($('#projects').length > 0){		
		var $container = $('#projects');
		
		$container.imagesLoaded(function() {
			$container.isotope({
			  // options
			  animationEngine: 'best-available',
			  itemSelector : '.portfolio-item',
			  layoutMode : 'fitRows'
			});
		});
	
		
		// filter items when filter link is clicked
		var $optionSets = $('#options .option-set'),
			$optionLinks = $optionSets.find('a');
	
		  $optionLinks.click(function(){
			var $this = $(this);
			// don't proceed if already selected
			if ( $this.hasClass('selected') ) {
			  return false;
			}
			var $optionSet = $this.parents('.option-set');
			$optionSet.find('.selected').removeClass('selected');
			$this.addClass('selected');
	  
			// make option object dynamically, i.e. { filter: '.my-filter-class' }
			var options = {},
				key = $optionSet.attr('data-option-key'),
				value = $this.attr('data-option-value');
			// parse 'false' as false boolean
			value = value === 'false' ? false : value;
			options[ key ] = value;
			if ( key === 'layoutMode' && typeof changeLayoutMode === 'function' ) {
			  // changes in layout modes need extra logic
			  changeLayoutMode( $this, options )
			} else {
			  // otherwise, apply new options
			  $container.isotope( options );
			}
			
			return false;
		});
	}
});


/* ==================================================
	Init
================================================== */
$(document).ready(function(){	
	'use strict';
	// Preload the page with jPreLoader
	$('body').jpreLoader({
		splashID: "#jSplash",
		showSplash: true,
		showPercentage: false,
		autoClose: true,
		splashFunction: function() {
			$('#circle').delay(250).animate({'opacity' : 1}, 500, 'linear');
		}
	});
	
	$('a[data-toggle=tooltip]').tooltip();

	$('.item-thumbs').bind('touchstart', function(){
		$(".active").removeClass("active");
      	$(this).addClass('active');
    });
	
	$('.image-wrap').bind('touchstart', function(){
		$(".active").removeClass("active");
      	$(this).addClass('active');
    });
	
	$('#social ul li').bind('touchstart', function(){
		$(".active").removeClass("active");
      	$(this).addClass('active');
    });

	$('#menu-nav, #menu-nav-mobile, #home-nav, #home-menu-nav').onePageNav({
		currentClass: 'current',
    	changeHash: false,
    	scrollSpeed: 750,
    	scrollOffset: 30,
    	scrollThreshold: 0.5,
		easing: 'easeOutExpo',
		filter: ':not(.external)'
	});

	$(function() {
	    $('.post-item').matchHeight();
	});
});

/*-----------------------------------------------------------------------------------*/
/*  NICESCROLL
/*-----------------------------------------------------------------------------------*/
jQuery(document).ready(function(){
	'use strict';
    jQuery("body").niceScroll({
      cursorcolor: '#202020',
      cursorwidth: 15,
      cursorborderradius: 0,
      cursorborder: '0px solid #fff',
      zindex: 10
    });
});

/* ==================================================
	Scroll to Top
================================================== */
$(document).ready(function(){
	'use strict';
	var windowWidth = $(window).width(),
		didScroll = false;

	var $arrow = $('#back-to-top');

	$arrow.click(function(e) {
		$('body,html').animate({ scrollTop: "0" }, 750, 'easeOutExpo' );
		e.preventDefault();
	})

	$(window).scroll(function() {
		didScroll = true;
	});

	setInterval(function() {
		if( didScroll ) {
			didScroll = false;

			if( $(window).scrollTop() > 1000 ) {
				$arrow.css('display', 'block');
			} else {
				$arrow.css('display', 'none');
			}
		}
	}, 250);

	$('#goUp').on('click', function(){
		$target = $($(this).attr('href')).offset().top-30;
		
		$('body, html').animate({scrollTop : $target}, 750, 'easeOutExpo');
		return false;
	});
});

/*-----------------------------------------------------------------------------------*/
/*  THEME FUNCTIONS
/*-----------------------------------------------------------------------------------*/
jQuery(document).ready(function(){
	'use strict';
	$("a[data-rel^='prettyPhoto']").prettyPhoto({
		social_tools: false,
		theme: 'light_square'
	});	
});

/*-----------------------------------------------------------------------------------*/
/*  ANIMATE
/*-----------------------------------------------------------------------------------*/
jQuery(document).ready(function($){
	'use strict';
	jQuery('.fade-up, .fade-down, .bounce-in, .flip-in, .fade-left, .fade-right, .fade-in').addClass('no-display');

	jQuery('.bounce-in').one('inview', function() { 
		jQuery(this).addClass('animated bounceIn appear');
	});
	jQuery('.flip-in').one('inview', function() { 
		jQuery(this).addClass('animated flipInY appear');
	});
	jQuery('.fade-up').one('inview', function() {
		jQuery(this).addClass('animated fadeInUp appear');
	});
	jQuery('.fade-down').one('inview', function() {
		jQuery(this).addClass('animated fadeInDown appear');
	});
	jQuery('.fade-left').one('inview', function() {
		jQuery(this).addClass('animated fadeInLeft appear');
	});
	jQuery('.fade-in').one('inview', function() {
		jQuery(this).addClass('animated fadeIn appear');
	});
	jQuery('.fade-right').one('inview', function() {
		jQuery(this).addClass('animated fadeInRight appear');
	});
	jQuery('.counter').counterUp({
		delay: 10,
		time: 1000
	});

});

/*-----------------------------------------------------------------------------------*/
/*  FANCY NAV
/*-----------------------------------------------------------------------------------*/
$(window).scroll(function() {
	'use strict';
    var scroll_pos = 0;
    $(document).scroll(function() { 
        scroll_pos = $(this).scrollTop();
        if(scroll_pos > 10) {     	        
            $('.home-nav').addClass('opaqued');
        } else {
            $('.home-nav').removeClass('opaqued');
        }
    });
});

$(document).scroll(function() {
	'use strict';
	var scroll_pos = 0;
    scroll_pos = $(this).scrollTop();
        if(scroll_pos > 10) {     	        
            $('.home-nav').addClass('opaqued');
        } else {
            $('.home-nav').removeClass('opaqued');
        }
});


/*-----------------------------------------------------------------------------------*/
/*  CONTACT FORM
/*-----------------------------------------------------------------------------------*/
jQuery(document).ready(function($){
	'use strict';

  $('#contactform').submit(function(){
    var action = $(this).attr('action');
    $("#message").slideUp(750,function() {
    $('#message').hide();
    $('#submit').attr('disabled','disabled');
    $.post(action, {
      name: $('#name').val(),
      email: $('#email').val(),
      website: $('#website').val(),
      comments: $('#comments').val()
    },
      function(data){
        document.getElementById('message').innerHTML = data;
        $('#message').slideDown('slow');
        $('#submit').removeAttr('disabled');
        if(data.match('success') != null) $('#contactform').slideUp('slow');
        $(window).trigger('resize');
      }
    );
    });
    return false;
  });
  
});

/*-----------------------------------------------------------------------------------*/
/*  SEARCH BAR
/*-----------------------------------------------------------------------------------*/
jQuery(document).ready(function($){
'use strict';

	jQuery(".logo-slider").owlCarousel({
	  items: 4,
	  pagination: true,
	  navigationText: [
	    "<i class='fa fa-angle-left icon-white'></i>",
	    "<i class='fa fa-angle-right icon-white'></i>"
	  ]
	});

});