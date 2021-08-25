export default class ImageMap {
    /**@param {'avatar' | 'banner'} type*/
    constructor(type) {
        this.type = type;
        this['default'] = this.require('default');
    }

    /**@param {string} key @param {string} value*/
    set(key, value) {
        this[key] = value;
    }
    /**@param {string} key*/
    delete(key) {
        this[key] = null;
    }
    /**@param {string} name @returns {string}*/
    require(name) {
        return require(`../../images/profile/${this.type}s/${name}.png`)?.default || this['default'];
    }

    /**@param {string} key @param {{}} options*/
    get(key, options) {
        return (
            <img src={this[key] || this['default']} 
                alt={`${key}'${new RegExp(/[x|s|z]$/).test(key) ? '' : 's'} profile ${this.type}`}
                {...options}
            />
        ) 
    }
}