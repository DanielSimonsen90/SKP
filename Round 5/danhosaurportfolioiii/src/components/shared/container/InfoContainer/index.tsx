import { BaseProps, classNames, ContainerType } from 'danholibraryrjs'
import { useTranslate } from 'providers/LanguageProvider'
import './InfoContainer.scss';

type InfoContainerType = Omit<ContainerType, 'popout'>;
type Props = BaseProps & {
    title: string
    type?: InfoContainerType
}

export default function InfoContainer({ className, title, children, type }: Props) {
    const translate = useTranslate();
    let _className = [
        'info-container',
        type && `info-container-${type}`,
        className
    ].filter(v => v).join(' ');
    
    return (
        <fieldset id={`info-container-${title.toLowerCase().replaceAll(' ', '-')}`} 
            className={classNames('info-container', type && `info-container-${type}`, className)}
        >
            <legend>{translate(title)}</legend>
            <section className="content">
                {children}
            </section>
        </fieldset>
    )
}
