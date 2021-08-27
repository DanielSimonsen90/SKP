import React from 'react'
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom'
export { Redirect, Route }

/**
 * @typedef Child
 * @type {string | JSX.Element}
 */

/**
 * 
 * @param {{
 *  children: Child[],
 *  routes?: [string, () => Child]
 * }} props 
 * @returns 
 */
export default function Router({ children, routes }) {
    return (
        <BrowserRouter>
            <Switch>
                {routes?.map(([path, component]) => (
                    <Route path={path} component={component} />
                )) || children}
            </Switch>
        </BrowserRouter>
    )
}
