(function () {
    const isMobile = () => window.innerWidth < 992;

    function handleDropdownToggle(evt) {
        const btn = evt.currentTarget;
        const parent = btn.closest('.dropdown');
        if (!parent) return;

        if (isMobile()) {
            evt.preventDefault();
            evt.stopPropagation();

            document.querySelectorAll('.nav-item.dropdown.show').forEach(function (openEl) {
                if (openEl !== parent) {
                    openEl.classList.remove('show');
                    const menu = openEl.querySelector('.dropdown-menu');
                    if (menu) menu.classList.remove('show');
                }
            });

            parent.classList.toggle('show');
            const myMenu = parent.querySelector('.dropdown-menu');
            if (myMenu) myMenu.classList.toggle('show');
        }
    }

    function handleDocumentClick(e) {
        const clickedInsideDropdown = e.target.closest('.nav-item.dropdown');
        if (!clickedInsideDropdown) {
            document.querySelectorAll('.nav-item.dropdown.show').forEach(function (openEl) {
                openEl.classList.remove('show');
                const menu = openEl.querySelector('.dropdown-menu');
                if (menu) menu.classList.remove('show');
            });
        }
    }

    document.addEventListener('DOMContentLoaded', function () {
        document.querySelectorAll('.nav-item.dropdown > .dropdown-toggle').forEach(function (toggle) {
            toggle.addEventListener('click', handleDropdownToggle);
        });

        document.querySelectorAll('.dropdown-menu').forEach(function (menu) {
            menu.addEventListener('click', function (e) {
                if (isMobile()) {
                    e.stopPropagation();
                }
            });
        });

        document.addEventListener('click', handleDocumentClick, true);

        window.addEventListener('resize', function () {
            if (!isMobile()) {
                document.querySelectorAll('.nav-item.dropdown.show, .dropdown-menu.show').forEach(function (el) {
                    el.classList.remove('show');
                });
            }
        });
    });
})();

const buttons = document.querySelectorAll('.country-btn');
const markers = document.querySelectorAll('.marker');

buttons.forEach(btn => {
    btn.addEventListener('click', () => {
        const country = btn.getAttribute('data-country');

        markers.forEach(m => m.classList.remove('blink'));
        buttons.forEach(b => b.classList.remove('active'));

        const marker = document.querySelector(`.marker[data-country="${country}"]`);
        if (marker) marker.classList.add('blink');
        btn.classList.add('active');

        const sectionContents = document.querySelectorAll('div[data-country-content]');
        sectionContents.forEach(section => {
            if (section.getAttribute('data-country-content') === country) {
                section.classList.remove('d-none');
            }
            else {
                section.classList.add('d-none');
            }
        });
    });
});

markers.forEach(marker => {
    marker.addEventListener('click', () => {
        const country = marker.getAttribute('data-country');

        markers.forEach(m => m.classList.remove('blink'));
        buttons.forEach(b => b.classList.remove('active'));

        marker.classList.add('blink');
        const btn = document.querySelector(`.country-btn[data-country="${country}"]`);
        if (btn) btn.classList.add('active');

    });
});

const car = document.querySelector('#miniCarousel');
if (car) {
    const bsCarousel = bootstrap.Carousel.getOrCreateInstance(car, { interval: 4000, ride: 'carousel' });
}

const sections = document.querySelectorAll('[data-section="key-services-content"]');

sections.forEach(section => {
    const pTags = section.querySelectorAll('p');

    pTags.forEach((p, index) => {
        if (index === 0) {
            const text = p.innerHTML.trim();

            const h5 = document.createElement('h5');
            h5.className = "card-title fs-6 fw-bold primary-color";
            h5.innerHTML = `<i class="bi bi-check-lg fs-5"></i> ${text}`;

            p.replaceWith(h5);
        } else {
            p.classList.add('card-text');
        }
    });
});

const images = document.querySelectorAll('.post-content img');

images.forEach(img => {
    img.style.width = '100%';
    img.style.height = 'auto';
    img.style.maxWidth = '100%'
});
