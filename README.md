# PickAndGo

Aplicação web .NET usada como laboratório de DevOps: Docker, GitHub Actions, Kubernetes (k3s) e publicação com HTTPS.

- API: https://pickandgo.atfengenharia.online/api/WeatherForecast

## Estrutura
- `backend/`: API ASP.NET Core (.NET 10), em camadas
- `frontend/`: futuro frontend React
- `docker/`: Dockerfile e Docker Compose
- `k8s/`: manifests do Kubernetes
- `infra/`: configuração do Apache (proxy reverso + HTTPS)
- `.github/workflows/`: CI (build, testes e imagem) e CD (publicação no GHCR)

## Fluxo
`feature/*` → PR para `develop` (squash) → PR `develop` → `main` (merge commit) → o CD publica a imagem no GHCR.
