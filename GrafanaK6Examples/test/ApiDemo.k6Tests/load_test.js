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
        http_req_duration: ['p(95)<300'], // 95% of requests must complete within 300ms
    },
    scenarios: {
        Scenario_1: {
            executor: 'ramping-vus',
            gracefulStop: '30s',
            stages: [
                { target: 20, duration: '10s' },
                { target: 20, duration: '30s' },
                { target: 0, duration: '10s' },
            ],
            gracefulRampDown: '30s',
            exec: 'scenario_1',
        },
        Scenario_2: {
            executor: 'ramping-vus',
            gracefulStop: '30s',
            stages: [
                { target: 5, duration: '10s' },
                { target: 10, duration: '30s' },
                { target: 9, duration: '10s' },
            ],
            gracefulRampDown: '30s',
            exec: 'scenario_2',
        },
    },
};

export function scenario_1() {
    // Get homepage
    let response = http.get('https://localhost:7203/api/Book/');

    // Automatically added sleep
    sleep(1);
}

export function scenario_2() {
    // Get homepage
    let response = http.get('https://localhost:7203/api/Book/b78c8056-149e-4e9f-b9e5-a29881e230de/');

    // Automatically added sleep
    sleep(1);
}