// Add custom footer
window.onload = function () {
    const footer = document.createElement('div');
    footer.className = 'swagger-footer';
    footer.innerHTML = '<div>Created by <b>Lam-HT-Backend</b></div>';
    document.body.appendChild(footer);
};
