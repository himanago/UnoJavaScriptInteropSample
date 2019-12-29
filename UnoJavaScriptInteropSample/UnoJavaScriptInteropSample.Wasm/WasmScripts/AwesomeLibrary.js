function sayHello() {
    alert('Hello from JS!');
}

function toReadonly(id) {
    const box = document.getElementById(id);
    box.getElementsByTagName('input')[0].setAttribute('readonly', 'readonly');
}

function addDblclickEventListener(id) {
    const box = document.getElementById(id);
    const tb = box.getElementsByTagName('input')[0];

    tb.addEventListener('dblclick', (e) => {
        box.dispatchEvent(new CustomEvent("dblclickEvent", { detail: e.target.id }));
    });
}
