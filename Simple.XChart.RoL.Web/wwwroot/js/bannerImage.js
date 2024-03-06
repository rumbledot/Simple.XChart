export function changeBannerBackground(imgUrl) {
    var banner = document.querySelector('.hero-banner');
    banner.style.backgroundImage = `url(${imgUrl})`;
}