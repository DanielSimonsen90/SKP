/**
 * 
 * @returns {(time: number) => Promise<void>}
 */
export default function useSleep() {
    return (time) => new Promise((resolve, reject) => {
        if (typeof time != 'number') reject({ message: 'Time is not a number!' });

        setTimeout(() => resolve(), time);
    });
}