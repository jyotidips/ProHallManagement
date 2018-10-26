jQuery(document).ready(function(){
	
	"use strict"; 

	var foo = $('.open-image');
		foo.poptrox({
		usePopupCaption: true
	});

	$(".open-menu-responsive").on("click",function(){
	    $(".responsive-menu").addClass("slidein");
	    return false;
	});
	$(".close-btn").on("click",function(){
	    $(".responsive-menu").removeClass("slidein");
	});
	$(".responsive-menu").on("click",function(e){
	    e.stopPropagation();
	});
	$(".responsive-menu li.menu-item-has-children > a").on("click",function(){
	    $(this).parent().siblings().children("ul").slideUp();
	    $(this).parent().siblings().removeClass("active");
	    $(this).parent().children("ul").slideToggle();
	    $(this).parent().toggleClass("active");
	    return false;
	});

	/*** QUICK POST SHARE ***/
	$('.quick-post-share > span').on('click', function (){
		$(this).parent().toggleClass('active');
	});

	/*================== Intagram Gallery =====================*/
    $('.insta-grab').slick({
	  centerMode: false,
	  centerPadding: '0',
	  slidesToShow: 8,
	  arrows: false,
	  autoplay:true,
	  responsive: [
	    {
	      breakpoint: 980,
	      settings: {
	        arrows: false,
	        centerMode: false,
	        centerPadding: '0',
	        slidesToShow: 6
	      }
	    },
	    {
	      breakpoint: 767,
	      settings: {
	        arrows: false,
	        centerMode: false,
	        centerPadding: '0',
	        slidesToShow: 4
	      }
	    },
	    {
	      breakpoint: 480,
	      settings: {
	        arrows: false,
	        centerMode: false,
	        centerPadding: '0',
	        slidesToShow: 2
	      }
	    }
	  ]
	});


	/*** ACCOUNT POPUP ***/	
	$('.email-btn > span').on('click', function(){
		$('.account-popup-sec').addClass('active');
		$('html').addClass('no-scroll');
	});
	$('.close-popup').on('click', function(){
		$('.account-popup-sec').removeClass('active');
		$('html').removeClass('no-scroll');
	});	

	$('.open-popup-menu').on('click', function(){
		$('html').addClass('no-scroll');
		$('.menu-bar3').addClass('show-menu');
	});
	$('.close-popup-menu').on('click', function(){
		$('html').removeClass('no-scroll');
		$('.menu-bar3').removeClass('show-menu');
	});

	/*=================== Parallax ===================*/   
	$('.parallax').scrolly({bgParallax: true});
	
	$('#contactform').submit(function(){
		var action = $(this).attr('action');
		$("#message").slideUp(750,function() {
		$('#message').hide();
 		$('#submit')
			.after('<img src="assets/ajax-loader.gif" class="loader" />')
			.attr('disabled','disabled');
		$.post(action, {
			name: $('#name').val(),
			email: $('#email').val(),
			comments: $('#comments').val(),
		},
			function(data){
				document.getElementById('message').innerHTML = data;
				$('#message').slideDown('slow');
				$('#contactform img.loader').fadeOut('slow',function(){$(this).remove()});
				$('#submit').removeAttr('disabled');
				if(data.match('success') != null) $('#contactform').slideUp('slow');

			}
		);

		});

		return false;

	});

});


$(window).load(function(){
	"use strict"; 

	$('.page-loading').fadeOut();
	$('html').addClass('done-scroll')

	var $dylay = jQuery('#dylay');
	$dylay.dylay({
		selector: '>div'
	});
	
});