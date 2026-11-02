# Architecture --- 설계 기준

## 1. 설계 원칙

-   한 클래스는 하나의 주요 책임을 가진다.
-   기능을 추가할 때 기존 클래스를 무조건 비대하게 만들지 않는다.
-   현재 규모에 필요한 만큼만 분리한다. 과도한 추상화와 디자인 패턴
    도입은 피한다.
-   클래스 간 참조는 필요한 방향으로만 둔다.
-   설계 변경 시 변경 이유와 영향 범위를 기록한다.

## 2. 목표 시스템 구성

### Core

-   `GameManager`: 게임 상태(Ready, Playing, GameOver 등)와 전체 게임
    흐름 관리

### Player

-   `PlayerController`: 입력과 이동
-   `PlayerHealth`: 체력, 피해, 회복, 사망 판정
-   `PlayerAttack`: 공격 입력, 공격 범위, 공격 쿨타임
-   `PlayerExperience`: 경험치와 레벨 관리

### Enemy

-   `EnemyController`: 플레이어 추적 등 적의 이동/행동
-   `EnemyHealth`: 적 체력, 피해, 사망 처리

### Spawn

-   `EnemySpawner`: 적 생성 위치와 생성 주기 관리

### Progression

-   `ExperienceOrb`: 경험치 아이템의 획득 처리
-   추후 필요 시 `UpgradeManager` 또는 강화 데이터 구조 추가

### UI

-   `UIManager`: 체력, 경험치, 레벨, 타이머, 게임 오버 UI 표시

## 3. 책임 및 관계

  -----------------------------------------------------------------------
  클래스                  책임                    주요 협력 대상
  ----------------------- ----------------------- -----------------------
  GameManager             게임 상태와 종료 흐름   PlayerHealth,
                                                  UIManager, EnemySpawner

  PlayerController        이동                    Rigidbody2D,
                                                  PlayerHealth

  PlayerHealth            플레이어 체력 및 사망   GameManager 또는 사망
                                                  이벤트

  PlayerAttack            공격 수행               PlayerController,
                                                  EnemyHealth

  EnemyController         플레이어 추적           Player Transform

  EnemyHealth             적 체력 및 사망         경험치 생성 로직

  EnemySpawner            적 생성                 Enemy 프리팹, 플레이어
                                                  위치

  PlayerExperience        경험치 및 레벨          ExperienceOrb,
                                                  UIManager

  ExperienceOrb           획득 시 경험치 전달     PlayerExperience

  UIManager               화면 표시               GameManager,
                                                  PlayerHealth,
                                                  PlayerExperience
  -----------------------------------------------------------------------

위 표는 목표 구조다. 모든 참조를 한꺼번에 구현하지 말고 기능이 필요한
시점에 연결한다.

## 4. 주요 이벤트 흐름

### 플레이어 사망

1.  `PlayerHealth`가 피해를 계산한다.
2.  체력이 0 이하가 되면 사망 상태를 한 번만 확정한다.
3.  사망 사실을 `GameManager`에 전달한다.
4.  `GameManager`가 게임 상태를 GameOver로 변경한다.
5.  `UIManager`가 게임 오버 화면을 표시한다.

### 적 사망

1.  `PlayerAttack`이 `EnemyHealth.TakeDamage()`를 호출한다.
2.  `EnemyHealth`가 체력을 감소시킨다.
3.  사망 상태를 한 번만 확정한다.
4.  경험치 보상을 생성하거나 보상 시스템에 알린다.
5.  적 오브젝트를 제거한다.

### 경험치 획득

1.  `ExperienceOrb`가 플레이어와의 접촉을 감지한다.
2.  `PlayerExperience`에 경험치를 전달한다.
3.  경험치가 요구량에 도달하면 레벨업한다.
4.  UI를 갱신하고 강화 선택을 진행한다.

## 5. 구현 시 주의사항

-   `GetComponent` 결과가 필요한 컴포넌트인지 확인하고, 누락 시 명확한
    오류를 출력한다.
-   `FindWithTag` 같은 전역 탐색은 초기 프로토타입에서는 허용하되,
    생성/초기화 구조가 복잡해지면 참조 전달 방식으로 개선한다.
-   사망 처리와 보상 지급은 중복 실행되지 않도록 상태 플래그 또는 동등한
    보호 장치를 둔다.
-   물리 이동은 Rigidbody2D 설정과 `FixedUpdate` 사용을 일관되게
    유지한다.
-   Unity Input System 설정과 코드의 입력 API가 일치하는지 확인한다.

## 6. 현재 코드에서 확인된 개선 후보

-   `PlayerController.cs`의 사용하지 않는 `using Unity.Jobs;` 제거
-   `PlayerHealth.cs`의 사용하지 않는
    `using UnityEngine.InputSystem.Processors;` 제거
-   `EnemyController.cs`의 사용하지 않는
    `using System.Runtime.CompilerServices;` 제거
-   `PlayerHealth`가 게임 오버 UI나 전체 게임 상태까지 직접 처리하지
    않도록 역할 분리
-   `EnemyHealth`의 사망 처리와 추후 보상 지급 경로 설계
-   `PlayerAttack`이 사망한 적을 중복 타격하지 않도록 사망 상태 고려

## 7. 설계 변경 기록

설계를 바꾸면 날짜, 변경 내용, 이유, 영향받는 클래스를
`DEVELOPMENT_LOG.md`에 기록한다.
