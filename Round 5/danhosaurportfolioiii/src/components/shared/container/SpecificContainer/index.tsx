import { BaseProps, Container } from 'danholibraryrjs';

type HTMLElements = JSX.IntrinsicElements;
type Arrayable<T> = T | Array<T>;

type Props<T extends keyof HTMLElements> = BaseProps & Record<'children', Arrayable<HTMLElements[T]>>
type InternalProps<ElementKey extends keyof HTMLElements> = Props<ElementKey> & Record<'type', ElementKey>

function SpecificContainer<Element extends keyof HTMLElements>({ children, type, className, ...props }: InternalProps<Element>) {
    return (
        <Container className={`${type}-container${className ? ` ${className}` : ''}`} {...props}>
            {children}
        </Container>
    )
}

export function ButtonContainer(props: Props<'button'>) {
    return <SpecificContainer type='button' {...props}/>
}
export function ImageContainer(props: Props<'img'>) {
    return <SpecificContainer type='img' {...props}/>
}