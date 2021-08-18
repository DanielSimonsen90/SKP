import React from 'react'
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom'
export { Redirect, Route }

export default function Router({ children, ...rest }) {
    return (
        <BrowserRouter>
            <Switch>
                {children}
            </Switch>
        </BrowserRouter>
    )
}
