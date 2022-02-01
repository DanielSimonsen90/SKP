import { createRef, DependencyList, useState, useEffect } from 'react';
import { useEffectOnce, useLoadData, UseLoadDataProps } from 'danholibraryrjs';
import { useTranslate } from 'providers/LanguageProvider';

type Props<T> = Omit<UseLoadDataProps<T>, 'loadingComponent' | 'errorComponent'> & {
    loadData(): Promise<T>;
    dependencies?: DependencyList;
    onLoadedChanged?: (loaded: number) => void;
    loadMessage?: string
    errorMessage?: string
}

export default function LoadData<T>({ loadData, dependencies, onLoadedChanged, valueComponent, loadMessage, errorMessage }: Props<T>) {
    const loadingProjects = createRef<HTMLHeadingElement>();
    const translate = useTranslate();
    
    const style = { display: 'flex', justifySelf: 'center' }

    const errorComponent = <h1 ref={loadingProjects} style={style}>{errorMessage || translate('unableToFetch')}</h1>;
    const loadingComponent = <h1 ref={loadingProjects} style={style}>{loadMessage || translate('loadingProjects')}...</h1>;

    const [component, loading] = useLoadData(loadData, { 
        errorComponent, valueComponent, loadingComponent
     }, dependencies)
    const [loaded, setLoaded] = useState(0);
    const timeout = setTimeout(() => {
        if (!loadingProjects.current) return;
        else if (loaded > 6) {
            clearTimeout(timeout);
            return loadingProjects.current.textContent = translate('unableToFetch');
        }

        const { textContent } = loadingProjects.current;
        let newValue = textContent + '.';
        if (textContent.endsWith('...')) {
            newValue = textContent.substring(0, textContent.length - 3);
        }
        loadingProjects.current.textContent = newValue;
        setLoaded(s => s + 1);
    }, 1000)

    useEffect(() => { onLoadedChanged?.(loaded); }, [loaded])
    useEffectOnce(() => () => clearTimeout(timeout))

    return component;
}
