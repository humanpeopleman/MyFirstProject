# 2D Top-Down Survival Game

## 프로젝트 소개
Unity와 C#으로 개발한 2D 탑다운 서바이벌 게임입니다.

플레이어는 적을 처치해 경험치를 획득하고, 레벨업을 통해 능력치를 강화하며 최대한 오래 생존해야 합니다.

## 개발 환경
- Engine: Unity
- Language: C#
- IDE: Visual Studio
- Platform: Windows
- Genre: 2D Top-Down Survival

## 주요 기능
- 플레이어 이동 및 공격
- 적 추적 AI
- 적 생성 시스템
- 경험치 및 레벨업 시스템
- 능력치 강화 선택
- 생존 시간에 따른 난이도 증가
- 체력 및 게임 오버 시스템
- 게임 재시작

## 조작법
- WASD / 방향키: 이동
- Space: 공격

## 개발 과정
- 객체별 책임을 분리한 컴포넌트 구조
- 이벤트를 활용한 시스템 간 데이터 전달
- 게임 상태에 따른 일시정지 및 재개 처리
- AI를 사용해 개발 설계 및 코드 리뷰
- 적의 플레이어 추적: `Vector2.MoveTowards`
- 공격 판정: `Physics2D.OverlapCircleAll`
- 시스템 간 통신: C# Event
- 게임 상태 관리: `GameState` 기반 상태 관리
- 경험치 처리: 누적 경험치 및 복수 레벨업 처리


## 스크린샷
<img width="300" height="643" alt="Upgrade" src="https://github.com/user-attachments/assets/5a368f56-8826-4100-954e-3aa455a7a923" />
<img width="300" height="643" alt="Gameplay" src="https://github.com/user-attachments/assets/b865b84a-452f-4a21-a994-be6a675bb4c1" />
<img width="300" height="643" alt="GameOver" src="https://github.com/user-attachments/assets/12bf981b-0945-4a5c-a265-223a50cfe6a8" />

## 플레이 영상 링크
https://youtube.com/shorts/5b5vIqf9tYc?feature=share

## 개발하면서 느낀 점
중학교 때 Unity 강의를 찾아보며 독학을 시도했지만, 혼자 학습하기에는 정보가 부족하고 어려움을 느껴 학원에 다녔던 경험이 있다.

이후 오랜만에 Unity를 다시 사용하게 되어, 엔진에 익숙해지고 기본적인 개발 감각을 되찾기 위해 이번 프로젝트를 시작했다.

이전에는 처음부터 큰 목표를 세우고 프로젝트를 진행하려 했지만, 당시 실력으로는 목표를 달성하기 어렵다고 판단해 개발을 중단한 경험이 있었다. 그래서 이번에는 목표를 작게 설정하고, 실제로 완성하는 것에 집중했다.

개발 과정에서 객체별 역할을 분리하는 방법, 이벤트를 활용한 시스템 간 통신, 게임 상태 관리 등을 직접 구현하며 익힐 수 있었다.

이번 프로젝트를 통해 처음부터 큰 규모의 프로젝트를 만드는 것보다, 작은 목표라도 끝까지 구현하고 완성하는 경험이 중요하다는 것을 배웠다.
