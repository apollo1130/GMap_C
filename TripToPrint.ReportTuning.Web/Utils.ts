module TripToPrint
{
    export class Utils {
        static extend<T, U>(first: T, second: U): T & U {
            let result = <T & U>{};
            for (let id in first) {
                result[id] = first[id];
            }
            for (let id in second) {
                result[id] = second[id];
            }
            return result;
        }
    }
}
