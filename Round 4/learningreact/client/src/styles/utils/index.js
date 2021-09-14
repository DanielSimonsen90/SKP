/**@param {string} cssName*/
export default function getVariable(cssName) {
    return getComputedStyle(document.documentElement)
        .getPropertyValue(cssName)
        .replace(/ +/, '');
}