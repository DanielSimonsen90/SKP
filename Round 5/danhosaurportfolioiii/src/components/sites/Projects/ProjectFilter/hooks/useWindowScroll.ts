import { useEffect, useState } from "react";
import { useAnimationReverse, useEventListener } from "danholibraryrjs";
import { GetCSSProperty } from "danholibraryjs";

export default function useWindowScroll(stick: number, className: string) {
    const [shouldStick, setShouldStick] = useState(false);
    useEventListener('scroll', e => setShouldStick((e.currentTarget as Window).scrollY > stick), window);
    const query = `.${className}`;
    const animateReverse = useAnimationReverse(query, 'animation-reverse', 
        GetCSSProperty('--animation-time', 'number', 
            document.querySelector(query) ? 
                query : 
                undefined
            )
        );

    useEffect(() => {
        const el = document.querySelector(query);
        if (!el) return;

        if (!shouldStick) animateReverse({ className: 'fixed' });
        else el.classList.add('fixed');
    }, [shouldStick])

    return shouldStick;
}