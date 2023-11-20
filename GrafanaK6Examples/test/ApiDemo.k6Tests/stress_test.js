import { sleep } from 'k6';
import http from 'k6/http';

export let options = {
    ext: {
        loadimpact: {
            projectID: 3670394,
            //distribution: {
            //    'amazon:us:ashburn': { loadZone: 'amazon:us:ashburn', percent: 34 },
            //    'amazon:gb:london': { loadZone: 'amazon:gb:london', percent: 33 },
            //    'amazon:au:sydney': { loadZone: 'amazon:au:sydney', percent: 33 },
            //},
        },
    },
    thresholds: {
        http_req_duration: ['p(95)<1000'], // 95% of requests must complete within 1000ms
        http_req_failed: ['rate<0.1'],     // Request failure rate should be less than 0.1%
    },
    stages: [
        { duration: '5s', target: 5 },    // Stage 1(5 seconds): Ramp - up to 5 virtual users over 5 seconds.
        { duration: '30s', target: 5 },   // Stage 2 (30 seconds): Stay at 5 virtual users for 30 seconds.
        { duration: '5s', target: 10 },   // Stage 3 (5 seconds): Ramp-up to 50 virtual users over 5 seconds.
        { duration: '30s', target: 10 },  // Stage 4 (30 seconds): Stay at 50 virtual users for 30 seconds.
        { duration: '5s', target: 20 },  // Stage 5 (5 seconds): Ramp-up to 100 virtual users over 5 seconds.
        { duration: '30s', target: 20 }, // Stage 6 (30 seconds): Stay at 100 virtual users for 30 seconds.
        { duration: '5s', target: 25 },  // Stage 7 (5 seconds): Ramp-up to 300 virtual users over 5 seconds.
        { duration: '30s', target: 10 }, // Stage 8 (30 seconds): Stay at 300 virtual users for 30 seconds.
        { duration: '5s', target: 0 },    // Stage 9 (5 seconds): Ramp-down to 0 virtual users over 5 seconds.
    ],
};

export default function () {
    let response = http.get('https://localhost:7203/api/Book'); // HTTP Get all books
    
    sleep(0.1); // Wait for 0.1 second between each request (adjust as needed for higher stress)
}