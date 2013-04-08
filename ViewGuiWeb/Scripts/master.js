/* BLOCO FIXA MENU SUPERIOR*/
$(function () {            
  var msie6 = $.browser == 'msie' && $.browser.version < 7;
  if (!msie6) {
    var top = $('#menu-sup').offset().top - parseFloat($('#menu-sup').css('margin-top').replace(/auto/, 0));
    $(window).scroll(function (event) {
      // what the y position of the scroll is
      var y = $(this).scrollTop();
      // whether that's below the form
      if (y >= top) {
        // if so, ad the fixed class
        $('#menu-sup').addClass('fixed');
      } else {
        // otherwise remove it
        $('#menu-sup').removeClass('fixed');
      }
    });
  }  
});
/*FIM DO BLOCO FIXA MENU*/
/* INICIO BLOCO VALIDA*/
   
/* FIM DO BLOCO VALIDADOR */