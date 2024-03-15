const copyMenu = () => {
    var dptCategory = document.querySelector('.dpt-cat')
    var dptPlace = document.querySelector('.departments')
    dptPlace.innerHTML = dptCategory.innerHTML;

    var mainNav = document.querySelector('.header-nav nav')
    var navPlace = document.querySelector('.off-canvas nav')
    navPlace.innerHTML = mainNav.innerHTML

    var topNav = document.querySelector('.header-top .wrapper')
    var topPlace = document.querySelector('.off-canvas .thetop-nav')
    topPlace.innerHTML = topNav.innerHTML
}

copyMenu()


window.onload = function (){
  document.querySelector('.site').classList.toggle('showmodal')
}

const menuButton = document.querySelector('.trigger'),
      closeButton = document.querySelector('.t-close'),
      addclass = document.querySelector('.site');
menuButton.addEventListener('click', function(){
    addclass.classList.toggle('showmenu')
})
closeButton.addEventListener('click', function(){
    addclass.classList.remove('showmenu')
})

const submenu = document.querySelectorAll('.has-child .icon-small')
submenu.forEach((menu) => menu.addEventListener('click', toggle))

function toggle(e) {
    e.preventDefault()
    submenu.forEach((item) => item!= this ? item.closest('.has-child').classList.remove('expand') : null)
    if(this.closest('.has-child').classList != 'expand');
    this.closest('.has-child').classList.toggle('expand')
}

const swiper = new Swiper('.swiper', {
    loop: true,
    
    pagination: {
      el: '.swiper-pagination',
    },
    autoplay: {
        delay: 2000,
        disableOnInteraction: false,
      },
  });

  const searchButton = document.querySelector('.t-search'),
        tClose = document.querySelector('.search-close'),
        showClass = document.querySelector('.site')
  searchButton.addEventListener('click', function(){
    showClass.classList.toggle('Showsearch')
  })

  tClose.addEventListener('click', function(){
    showClass.classList.remove('Showsearch')
  })

  const dptButton = document.querySelector('.dpt-cat .dpt-trigger'),
        dptClass = document.querySelector('.site')
    dptButton.addEventListener('click', function(){
        dptClass.classList.toggle('showdpt')
    })

  var productThumb = new Swiper('.small-image', {
    loop: true,
    spaceBetween: 10,
    slidesPerView: 3,
    freeMode: true,
    watchSlidesProgress: true,
    breakpoints: {
      481:{
        spaceBetween: 32,
      }
    }
  });

  var productBig = new Swiper('.big-image', {
    loop: true,
    autoHeight: true,
    navigation:{
      nextEl: '.swiper-button-next',
      prevEl: '.swiper-button-prev'
    },
    autoplay: {
      delay: 2000,
    },
    thumbs:{
      swiper: productThumb,
    }
  });

/*  var stocks = document.querySelectorAll('.products .stock')
for (let x = 0; x <= stocks.length; x++){
    let stock = stocks[x].getAttribute("stock");
    let available = stocks[x].querySelector('.qty-available').innerHTML,
    sold = stocks[x].querySelector('.qty-sold').innerHTML,
    percent = sold*100/stock;
    
    stocks[x].querySelector('.available').style.width = percent + '%'
  }
  */
function decreaseQuantity() {
    if (initialQuantity > 1) {
        initialQuantity -= 1;
        console.log("Hello");
        updateInputValue();
    }
}

function increaseQuantity() {
    initialQuantity += 1;
    console.log(initialQuantity)
    updateInputValue();
}

function updateInputValue() {
    // Cập nhật giá trị trong input bằng giá trị của @Model.Quantity
    var inputElement = document.querySelector('input[asp-for="@Model.Quantity"]');
    if (inputElement) {
        inputElement.value = initialQuantity;
    }
}
