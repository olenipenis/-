import http from 'k6/http';
import { sleep, check } from 'k6';

export const options = {
  vus: 10,
  duration: '30s',
};

export default function() {
  let res = http.get('https://quickpizza.grafana.com');
  check(res, { "status is 200": (res) => res.status === 200,
  "body is not empty": (res) => res.body.length > 0,
  "response time < 1000ms": (res) => res.timing < 1000
   });
  sleep(1);
}
