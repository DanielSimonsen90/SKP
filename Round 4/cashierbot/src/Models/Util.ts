export function Random(length: number) {
    return Math.floor(Math.random() * (1000 * length));
}
export async function Wait(time: number) {
    return new Promise<void>(resolve => {
        setTimeout(() => {
            resolve();
        }, Random(time))
    })
}