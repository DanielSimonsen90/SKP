export default function useRedirect() {
    /**@param {string} to*/
    return function(to) {
        window.location.pathname = to;
    }
}