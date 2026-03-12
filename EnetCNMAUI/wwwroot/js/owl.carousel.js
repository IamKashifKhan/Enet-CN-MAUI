$(document).ready(function(){

  $('.categories-slider').owlCarousel({
    loop:true,
    margin:30,
    nav:false,
    dots:false,
     autoplay: true,
    autoplayTimeout: 3500,
    smartSpeed: 900,
    dotsEach: 1,   // IMPORTANT	  
    responsive:{
      0:{items:3},
	  480:{items:4},
	  768:{items:5},
      991:{items:6},
	  1200:{items:9},
		
    }
  });

 $('.hero-slider').owlCarousel({
    items: 1,
    loop: true,
    nav: false,
    dots: true,
    autoplay: true,
    autoplayTimeout: 4000,
    smartSpeed: 800,
    dotsEach: 1,   // IMPORTANT
    navText: [
        '<i class="fa fa-chevron-left"></i>',
        '<i class="fa fa-chevron-right"></i>'
    ]
});


var redeemedSlider = $('.redeemed-slider');

redeemedSlider.owlCarousel({
  loop:true,
  margin:20,
  nav:false,
  dots:false,
  autoplay:true,
  autoplayTimeout:5000,
  smartSpeed:900,
  dotsEach:1,
  stagePadding:100,
  responsive:{
    0:{items:1, stagePadding:30},
    768:{items:2, stagePadding:50},
    1200:{items:3, stagePadding:100}
  }
});

// Stop autoplay on first user interaction
redeemedSlider.on('mousedown touchstart', function () {
  redeemedSlider.trigger('stop.owl.autoplay');
});
	




var offersSlider = $('.offers-slider');

offersSlider.owlCarousel({
  loop:true,
  margin:20,
  nav:false,
  dots:false,
  autoplay:true,
  autoplayTimeout:5000,
  smartSpeed:900,
  dotsEach:1,
  stagePadding:5,
  responsive:{
    0:{items:2},
    576:{items:3},
    768:{items:5},
    1200:{items:6}
  }
});

// Stop autoplay on first user interaction
offersSlider.on('mousedown touchstart', function () {
  offersSlider.trigger('stop.owl.autoplay');
});
	

	
	
	
	
	
	
	
	
	/* Toggle */
$('.toggle-wrapper button').click(function(){
  $('.toggle-wrapper button').removeClass('active');
  $(this).addClass('active');
  $('#offersScreen, #businessScreen').addClass('hidden');
  $('#' + $(this).data('target')).removeClass('hidden');
});

/* Heart */
$(document).on('click','.heart',function(){
  $(this).text($(this).text() === "♡" ? "♥" : "♡");
});

/* Suggested Owl */
var suggestedSlider = $('.suggested-slider');

suggestedSlider.owlCarousel({
  loop:true,
  margin:15,
  nav:false,
  dots:false,
  autoplay:true,
  autoplayTimeout:3000,
  smartSpeed:600,
  responsive:{
    0:{ items:1.2 },
    576:{ items:1.2 },
    768:{ items:1.2 }
  }
});

// Stop autoplay on user interaction
suggestedSlider.on('mousedown touchstart', function () {
  suggestedSlider.trigger('stop.owl.autoplay');
});
	
	
	
/* Premium Accordion Logic */

$('.business-header').on('click', function(){

  const parent = $(this).closest('.business-item');
  const body = parent.find('.business-body');

  if(parent.hasClass('active')){
      parent.removeClass('active');
  } else {

      /* Close others */
      $('.business-item').removeClass('active');

      parent.addClass('active');

      /* Lazy Owl Init */
      if(!body.data('owl-initialized')){
          body.find('.inner-slider').owlCarousel({
              loop:true,
              margin:15,
              nav:false,
              dots:false,
              autoplay:true,
              autoplayTimeout:3000,
              smartSpeed:600,
              responsive:{
                  0:{ items:1.2 },
                  768:{ items:1.2 }
              }
          });

          body.data('owl-initialized', true);
      }
  }
});


/* Auto Close On Scroll */
$(window).on('scroll', function(){
  // $('.business-item').removeClass('active');
});



/* Heart Animation */
$(document).on('click', '.heart', function () {
  $(this).toggleClass('active');

  if ($(this).hasClass('active')) {
    $(this).html('<i class="fa-solid fa-heart"></i>');
  } else {
    $(this).html('<i class="fa-regular fa-heart"></i>');
  }
});
	
	 });
	
	
	
	
	



